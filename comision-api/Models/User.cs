using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComisionQA.Models
{
    [Table("users")]
    public class User
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string? code { get; set; }
        public bool status { get; set; }
        public int rolId { get; set; }
        public Rol rol { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public DateTime? deletedAt { get; set; }
        public Profile profile { get; set; }

        public void updatePropeties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(b => b.createdAt)
                .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<User>()
                .Property(b => b.updatedAt)
                .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<User>()
                .Property(b => b.status)
                .HasDefaultValue(true);
            modelBuilder.Entity<User>()
                .HasOne<Rol>(u => u.rol)
                .WithMany(r => r.users)
                .HasForeignKey(u => u.rolId);
        }

    }
}
