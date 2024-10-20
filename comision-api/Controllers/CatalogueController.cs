using ComisionQA;
using ComisionQA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;


namespace comision_api.Controllers
{
    [Route("api/catalogue")]
    [ApiController]
    public class CatalogueController : ControllerBase
    {
        private readonly ComisionQaContext _context;
        public CatalogueController(ComisionQaContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> findAll()
        {
            var catalogues = await _context.Catalogues.Include(c => c.Brands)
                .ThenInclude(b => b.VehicleModels).ToListAsync();
            return Ok(catalogues);
        }
        [HttpPost]
        public async Task<IActionResult> store([FromBody] Catalogue newCatalogue)
        {
            _context.Catalogues.Add(newCatalogue);
            await _context.SaveChangesAsync();
            return Ok(new CustomResponse(newCatalogue).ok());
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> update([FromBody] Catalogue updateCatalogue, int id)
        {
            if (!await this.IsExist(id))
            {
                return NotFound(new CustomResponse("Catalogue not found").notFound());
            }
            var catalogue = await _context.Catalogues.FindAsync(id);
            catalogue.name = updateCatalogue.name;
            catalogue.updatedAt = DateTime.UtcNow;
            _context.SaveChanges();
            Console.WriteLine(catalogue.updatedAt?.ToString("yyyy-MM-dd HH:mm:ss"));
            return Ok(new CustomResponse(catalogue).updated());
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.Catalogues.AnyAsync(c => c.Id == id);
        }
    }
}
