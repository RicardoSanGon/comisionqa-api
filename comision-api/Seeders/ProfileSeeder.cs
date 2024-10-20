using ComisionQA;
using ComisionQA.Models;

namespace comision_api.Seeders
{
    public class ProfileSeeder
    {
        private readonly ComisionQaContext _context;
        public ProfileSeeder(ComisionQaContext context)
        {
            this._context = context;
        }

        public async Task<bool> fillData()
        {
            try
            {
                _context.Database.EnsureCreated();

                var profiles = new Profile[] {
                new Profile(){ firstname="Administrador", 
                    paternal="Del", 
                    maternal="Sistema",
                    userId=1},
                new Profile(){ firstname="Cliente",
                    paternal="Del",
                    maternal="Sistema",
                    userId=2 },
                new Profile(){ firstname="Invitado",
                    paternal="Del",
                    maternal="Sistema",
                    userId=3 }
                };
                foreach (var profile in profiles)
                {
                    await _context.Profiles.AddAsync(profile);
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
