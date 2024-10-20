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
            var rols = await _context.Rols.Include(r=>r.Users).ThenInclude(u=>u.profile).ToListAsync();
            return Ok(rols);
        }
        [HttpGet("{id}")]
        async public Task<ActionResult> findById(int id)
        {
            var rol = await _context.Rols.Include(r => r.Users).ThenInclude(u => u.profile).FirstOrDefaultAsync(r => r.Id == id);
            if (rol == null)
            {
                return NotFound();
            }
            return Ok(rol);
        }
    }
}
