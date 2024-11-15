using comision_api.Dto;
using comision_api.Services;
using ComisionQA;
using ComisionQA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace comision_api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ComisionQaContext _context;
        private readonly IConfiguration _configuration;
        public AuthController(ComisionQaContext context, IConfiguration configuration)
        {
            this._context = context;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> register([FromBody] UserDto user)
        {
            if (user == null) return BadRequest();
            var newUser = new User
            {
                email = user.email,
                password = HashHelper.Encrypt(user.password),
                profile = new Profile
                {
                    firstname = user.firstname,
                    maternal = user.maternal,
                    paternal = user.paternal,
                    phone = user.phone,
                    address = user.address,
                    username = user.firstname + '.' + user.paternal
                },
                verificationToken = Guid.NewGuid().ToString()
            };
            var email = new EmailService(_configuration);
            var url = "http://localhost:5002/api/auth/verify/" + newUser.verificationToken;
            
            if(!await email.VerifyEmail(newUser.profile.firstname, newUser.email, url))
            {
                return Problem(statusCode: StatusCodes.Status500InternalServerError, detail: "Something went wrong");
            }
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return Ok(new CustomResponse(newUser).created());
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> login([FromBody] LoginDto loginUser)
        {
            if (loginUser == null) return BadRequest();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.email == loginUser.email);
            if (user == null) return NotFound(new CustomResponse("User not found").notFound());
            if(user.verified == false) return Unauthorized(new CustomResponse("User not verified").unauthorized());
            if (!HashHelper.Verify(loginUser.password, user.password)) return Unauthorized(new CustomResponse("Invalid credentials").unauthorized());
            var authClaims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("id", user.Id.ToString())
                };
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddDays(1),
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                claims: authClaims
                );
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
        [Route("profile")]
        [Authorize]
        public async Task<IActionResult> profile()
        {
            var userId = User.FindFirstValue("id");
            var user = await _context.Users.Include(u => u.profile).FirstOrDefaultAsync(u => u.Id == int.Parse(userId));
            return Ok(user);
        }

        [HttpGet]
        [Route("verify/{token}")]
        public async Task<IActionResult> verifyEmail(string token)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.verificationToken == token);
            if (user == null) return NotFound(new CustomResponse("User not found").notFound());
            user.verified = true;
            user.verificationToken = null;
            await _context.SaveChangesAsync();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "src", "views", "CuentaActivada.html");
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("El archivo de la vista no se encuentra.");
            }
            return PhysicalFile(filePath, "text/html");
        }
    }
}
