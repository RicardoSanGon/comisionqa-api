using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ComisionQA.Models
{
    [Table("roles")]
    public class Rol
    {
        public int? Id { get; set; }
        [Required]
        public string name { get; set; }
        public bool? status { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public DateTime? deletedAt { get; set; }
        [JsonIgnore]
        public ICollection<User>? Users { get; set; }
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
