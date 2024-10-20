using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComisionQA.Models
{
    [Table("profiles")]
    public class Profile
    {
        public int Id { get; set; }
        public string firstname { get; set; }
        public string maternal { get; set; }
        public string paternal { get; set; }
        public string? username { get; set; }
        public string? phone { get; set; }
        public string? address { get; set; }
        public int userId { get; set; }
        public User User { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public DateTime? deletedAt { get; set; }

        public void updatePropeties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>()
                .Property(b => b.createdAt)
                .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<Profile>()
                .Property(b => b.updatedAt)
                .HasDefaultValueSql("NOW()");

            modelBuilder.Entity<Profile>()
                .HasOne<User>(p => p.User)
                .WithOne(u => u.profile)
                .HasForeignKey<Profile>(p => p.userId);
        }
    }
}
