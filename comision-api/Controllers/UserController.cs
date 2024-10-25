using ComisionQA;
using ComisionQA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace comision_api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ComisionQaContext _context;

        public UserController(ComisionQaContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> findAll()
        {
            var users = await _context.Users.Include(u=>u.Rol).Include(u=>u.profile).Select(u => new
            {
                u.Id,
                u.email,
                u.status,
                u.rolId,
                u.Rol,
                u.profile
            }).ToListAsync();
            return Ok(users);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> findOne(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound(new CustomResponse("User not found").notFound());
            }
            return Ok(user);
        }

        
        [HttpPost]
        public async Task<IActionResult> store([FromBody] User newUser)
        {
            if(newUser == null)
            {
                return BadRequest();
            }
            try
            {
                newUser.password = HashHelper.Encrypt(newUser.password);
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();
                return Ok(new CustomResponse(newUser).created());
            }
            catch (Exception ex)
            {
                return Problem(statusCode: StatusCodes.Status500InternalServerError, detail: "Something went wrong");
            }
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> update(int id, [FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            try
            {
                var userToUpdate = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
                if (userToUpdate == null)
                {
                    return NotFound(new CustomResponse("User not found").notFound());
                }
                userToUpdate.email = user.email;
                userToUpdate.password = user.password;
                userToUpdate.code = user.code;
                userToUpdate.rolId = user.rolId;
                userToUpdate.updatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return Ok(new CustomResponse(userToUpdate).updated());
            }
            catch (Exception ex)
            {
                return Problem(statusCode: StatusCodes.Status500InternalServerError, detail: "Something went wrong");
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> destroy(int id)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
                if (user == null)
                {
                    return NotFound(new CustomResponse("User not found").notFound());
                }
                user.status = !user.status;
                user.deletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return Ok(new CustomResponse(user).deleted());
            }
            catch (Exception ex)
            {
                return Problem(statusCode: StatusCodes.Status500InternalServerError, detail: "Something went wrong");
            }
        }
    }
}
