using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace ComisionQA.Models
{
    [Table("catalogues")]
    public class Catalogue
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30,MinimumLength = 3)]
        public string name { get; set; }
        public bool? status { get; set; } = true;
        public DateTime createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public DateTime? deletedAt { get; set; }
        public ICollection<Brand>? Brands { get; set; }

        public void updatePropeties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catalogue>()
                .Property(b => b.createdAt)
                .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<Catalogue>()
                .Property(b => b.updatedAt)
                .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<Catalogue>()
                .Property(b => b.status)
                .HasDefaultValue(true);
            modelBuilder.Entity<Catalogue>()
                .HasMany<Brand>(c => c.Brands)
            .WithOne(b => b.Catalogue)
                .HasForeignKey(b => b.catalogueId);
        }

       
    }
}
