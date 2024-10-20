using comision_api.Seeders;
using Microsoft.EntityFrameworkCore;

namespace ComisionQA.Seeders
{
    public class Index
    {
        private readonly ComisionQaContext _context;
        public Index(ComisionQaContext context)
        {
            this._context = context;
        }
        async public Task<bool> Seed()
        {
            return await new RolSeeder(_context).fillData() && await new UserSeeder(_context).fillData() 
                && await new ProfileSeeder(_context).fillData() && await new CatalogueSeeder(_context).fillData();
        }
    }
}
