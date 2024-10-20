using ComisionQA;
using ComisionQA.Models;

namespace comision_api.Seeders
{
    public class CatalogueSeeder
    {
        private readonly ComisionQaContext _context;
        public CatalogueSeeder(ComisionQaContext context)
        {
            this._context = context;
        }

        public async Task<bool> fillData()
        {
            try
            {
                _context.Database.EnsureCreated();

                var catalogues = new Catalogue[] {
                new Catalogue(){ name="Sedan" },
                new Catalogue(){ name="Hatchback" },
                new Catalogue(){ name="Pickup" },
                new Catalogue(){ name="Sport car" },
                new Catalogue(){ name="Luxury car" },
                new Catalogue(){ name="Commercial" },
                new Catalogue(){ name="Convertible" }
                };
                foreach (var catalogue in catalogues)
                {
                    await _context.Catalogues.AddAsync(catalogue);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
