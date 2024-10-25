
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComisionQA.Models
{
    [Table("brands")]
    public class Brand
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string name { get; set; }
        public bool? status { get; set; }
        [Required]
        public int catalogueId { get; set; }
        public Catalogue? Catalogue { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public DateTime? deletedAt { get; set; }
        public ICollection<VehicleModel>? VehicleModels { get; set; }

        public void updatePropeties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .Property(b => b.createdAt)
                .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<Brand>()
                .Property(b => b.updatedAt)
                .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<Brand>()
                .Property(b => b.status)
                .HasDefaultValue(true);
            modelBuilder.Entity<Brand>()
                .HasMany<VehicleModel>(b => b.VehicleModels)
                .WithOne(vm => vm.Brand)
                .HasForeignKey(vm => vm.brandId);
        }
    }
}
