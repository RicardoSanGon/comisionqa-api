using ComisionQA;
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

        async public Task<List<Rol>> findAll()
        {
            return await _context.Rols.ToListAsync<Rol>();
        }
    }
}
