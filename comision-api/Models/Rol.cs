using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComisionQA.Models
{
    [Table("roles")]
    public class Rol
    {
        public int? Id { get; set; }
        public string name { get; set; }
        public bool? status { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public DateTime? deletedAt { get; set; }
        public List<User> users { get; set; }

        public void updatePropeties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>()
                .Property(b => b.createdAt)
                .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<Rol>()
                .Property(b => b.updatedAt)
                .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<Rol>()
                .Property(b => b.status)
                .HasDefaultValue(true);
            
        }
    }
}
