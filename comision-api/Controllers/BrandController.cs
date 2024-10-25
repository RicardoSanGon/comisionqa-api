using ComisionQA;
using ComisionQA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace comision_api.Controllers
{
    [Route("api/brand")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly ComisionQaContext _context;

        public BrandController(ComisionQaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> GetBrands()
        {
            var brands = await _context.Brands.Include(b=>b.Catalogue).Include(b=>b.VehicleModels).ToListAsync();
            return Ok(brands);
        }

        [HttpPost]
        public async Task<IActionResult> store([FromBody] Brand brand)
        {
            if (brand == null)
            {
                return BadRequest();
            }
            if(!await _context.Catalogues.AnyAsync(c => c.Id == brand.catalogueId))
            {
                ModelState.AddModelError("error", "Catalogue not found");
                return BadRequest(ModelState);
            }
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
            return Ok(new CustomResponse(brand).created());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> update(int id, [FromBody] Brand brand)
        {
            if (brand == null)
            {
                return BadRequest();
            }
            var brandToUpdate = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);
            if (brandToUpdate == null)
            {
                return NotFound();
            }
            brandToUpdate.name = brand.name;
            brandToUpdate.catalogueId = brand.catalogueId;
            brandToUpdate.updatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return Ok(new CustomResponse(brandToUpdate).updated());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> destroy(int id)
        {
            var brand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);
            if (brand == null)
            {
                return NotFound();
            }
            brand.status = !brand.status;
            brand.deletedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return Ok(new CustomResponse(brand).deleted());
        }
    }
}
