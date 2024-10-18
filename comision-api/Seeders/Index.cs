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
            bool resRoles = await new RolSeeder(_context).fillData();
            bool resUsers = await new UserSeeder(_context).fillData();
            return resRoles && resUsers;
        }
    }
}
