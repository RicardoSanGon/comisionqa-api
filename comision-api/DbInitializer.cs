using Microsoft.EntityFrameworkCore;


namespace ComisionQA
{
    public class DbInitializer
    {
        private readonly ComisionQaContext _context;
        public DbInitializer(ComisionQaContext context)
        {
            this._context = context;
        }
        async public Task<bool> Seed()
        {
            return await new Seeders.Index(_context).Seed();
        }
    }
}
