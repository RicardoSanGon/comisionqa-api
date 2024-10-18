using Microsoft.EntityFrameworkCore;
using ComisionQA.Models;

namespace ComisionQA.Seeders
{
    public class RolSeeder
    {
        private readonly ComisionQaContext _context;
        public RolSeeder(ComisionQaContext context)
        {
            this._context = context;
        }

        async public Task<bool> fillData()
        {
            try
            {
                _context.Database.EnsureCreated();
                var roles = new Rol[]
                {
                new Rol{Id=1, name="Adminitrador"},
                new Rol{Id=2, name="Cliente"},
                new Rol{Id=3, name="Invitado"}
                };
                foreach (var rol in roles)
                {
                    await _context.Rols.AddAsync(rol);
                }
                await _context.SaveChangesAsync();
                return true;
            }catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }
    }
}
