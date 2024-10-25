using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ComisionQA.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ComisionQA
{
    public class ComisionQaContext : DbContext
    {
       
        public ComisionQaContext(DbContextOptions<ComisionQaContext> options)
            : base(options)
        {
            
        }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new Rol().updatePropeties(modelBuilder);
            new User().updatePropeties(modelBuilder);
            new Profile().updatePropeties(modelBuilder);
            new OrderDetail().updatePropeties(modelBuilder);
            new VehicleModel().updatePropeties(modelBuilder);
            new Supplier().updatePropeties(modelBuilder);
            new Profile().updatePropeties(modelBuilder);
            new Brand().updatePropeties(modelBuilder);
            new Catalogue().updatePropeties(modelBuilder);

        }



        public DbSet<ComisionQA.Models.Rol> Rols { get; set; }
        public DbSet<ComisionQA.Models.User> Users { get; set; }
        public DbSet<ComisionQA.Models.VehicleModel> Vehicle_Models { get; set; }
        public DbSet<ComisionQA.Models.Profile> Profiles { get; set; }
        public DbSet<ComisionQA.Models.OrderDetail> OrderDetails { get; set; }
        public DbSet<ComisionQA.Models.SaleHistory> SaleHistories { get; set; }
        public DbSet<ComisionQA.Models.Order> Orders { get; set; }
        public DbSet<ComisionQA.Models.Brand> Brands{ get; set; }
        public DbSet<ComisionQA.Models.Catalogue> Catalogues { get; set; }
    }
}
