using ComisionQA;
using ComisionQA.Migrations;
using ComisionQA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace comision_api.Controllers
{
    [Route("api/rol")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly ComisionQaContext _context;
        public RolController(ComisionQaContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> findAll()
        {
            var rols = await _context.Rols.ToListAsync();
            return Ok(rols);
        }
        [HttpGet("{id}")]
        async public Task<IActionResult> findById(int id)
        {
            var rol = await _context.Rols.FirstOrDefaultAsync(r => r.Id == id);
            if (rol == null)
            {
                return NotFound();
            }
            return Ok(rol);
        }
        [HttpPost]
        public async Task<IActionResult> store([FromBody] Rol rol)
        {
            if (rol == null)
            {
                return BadRequest();
            }
            try
            {
                _context.Rols.Add(rol);
                await _context.SaveChangesAsync();
                return Ok(new CustomResponse(rol).created());
            }
            catch (Exception ex) {
                return Problem(statusCode: StatusCodes.Status500InternalServerError, detail: "Something went wrong");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> update(int id, [FromBody] Rol updateRol)
        {
            if(updateRol == null)
                return BadRequest();
            try
            {
                var rol = await _context.Rols.FirstOrDefaultAsync(r => r.Id == id);
                if(rol == null)
                { return NotFound(new CustomResponse("Rol not found").notFound()); }
                rol.name = updateRol.name;
                rol.updatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return Ok(new CustomResponse(rol).updated());
            }
            catch (Exception ex)
            {
                return Problem(statusCode: StatusCodes.Status500InternalServerError, detail: "Something went wrong");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> destroy(int id)
        {
            try
            {
                var rol = await _context.Rols.FirstOrDefaultAsync(r => r.Id == id);
                if (rol == null)
                    return NotFound(new CustomResponse("Rol not found").notFound());
                rol.status = !rol.status;
                rol.deletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return Ok(new CustomResponse(rol).deleted());
            }
            catch (Exception ex)
            {
                return Problem(statusCode: StatusCodes.Status500InternalServerError, detail: "Something went wrong");
            }
        }
    }
}
