using ComisionQA.Models;

namespace ComisionQA.Seeders
{
    public class UserSeeder
    {
        private readonly ComisionQaContext _context;
        public UserSeeder(ComisionQaContext context)
        {
            this._context = context;
        }

        async public Task<bool> fillData()
        {
            try
            {
                _context.Database.EnsureCreated();
                
                var users = new User[] {
                new User(){ rolId=1, email="admin@comisionqa.com", password=HashHelper.Encrypt("admin123") },
                new User(){ rolId=2, email="cliente@comisionqa.com", password=HashHelper.Encrypt("cliente123") },
                new User(){ rolId=3, email="invitado@comisionqa.com", password=HashHelper.Encrypt("invitado123") }
                };
                foreach (var user in users)
                {
                    await _context.Users.AddAsync(user);
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
