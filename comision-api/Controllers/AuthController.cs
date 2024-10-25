using comision_api.Dto;
using ComisionQA;
using ComisionQA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
                }
            };
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
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
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
    }
}
