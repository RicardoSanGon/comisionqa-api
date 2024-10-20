using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComisionQA.Models
{
    [Table("vehicle_models")]
    public class VehicleModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string year { get; set; }
        public string? description { get; set; }
        public float price { get; set; }
        public int stock { get; set; }
        public bool? status { get; set; } = true;
        public int brandId { get; set; }
        public Brand Brand { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public DateTime? deletedAt { get; set; }
        public List<Inventory> Inventories { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<SaleHistory> SaleHistory { get; set; }

        public void updatePropeties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleModel>()
                .Property(vm => vm.createdAt)
                .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<VehicleModel>()
                .Property(vm => vm.updatedAt)
                .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<VehicleModel>()
                .Property(vm => vm.status)
                .HasDefaultValue(true);
            modelBuilder.Entity<VehicleModel>()
                .HasMany<Inventory>(vm => vm.Inventories)
                .WithOne(i => i.VehicleModel)
                .HasForeignKey(i => i.vehicleModelId);
            modelBuilder.Entity<VehicleModel>()
                .HasMany<OrderDetail>(vm => vm.OrderDetails)
                .WithOne(od => od.VehicleModel)
                .HasForeignKey(od => od.vehicleModelId);
            modelBuilder.Entity<VehicleModel>()
                .HasMany<SaleHistory>(vm => vm.SaleHistory)
                .WithOne(sh => sh.Vehicle)
                .HasForeignKey(sh => sh.vehicleId);
        }
    }
}
