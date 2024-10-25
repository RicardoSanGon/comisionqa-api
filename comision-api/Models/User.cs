using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComisionQA.Models
{
    [Table("users")]
    public class User
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 8)]
        [JsonIgnore]
        public string password { get; set; }
        public string? code { get; set; }
        public bool? status { get; set; }
        public int? rolId { get; set; } = 3;
        public Rol? Rol { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public DateTime? deletedAt { get; set; }
        public Profile? profile { get; set; }

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
                .HasOne<Rol>(u => u.Rol)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.rolId);
            modelBuilder.Entity<User>()
                .HasOne<Profile>(u => u.profile)
                .WithOne(p => p.User)
                .HasForeignKey<User>(u => u.Id);
            modelBuilder.Entity<User>()
                .HasIndex(u => u.email)
                .IsUnique();
        }

    }
}
