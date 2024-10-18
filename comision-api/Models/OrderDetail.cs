using Microsoft.EntityFrameworkCore;

namespace ComisionQA.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int quantity { get; set; }
        public double total { get; set; }
        public int detailStatus { get; set; } //0 pendiente, 1 entregado, 2 retrasado, 3 cancelado
        public DateTime deliveryDate { get; set; }
        public int vehicleModelId { get; set; }
        public VehicleModel VehicleModel { get; set; }
        public int orderId { get; set; }
        public Order Order { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public DateTime? deletedAt { get; set; }

        public void updatePropeties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>()
                .Property(od => od.createdAt)
                .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<OrderDetail>()
                .Property(od => od.updatedAt)
                .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<OrderDetail>()
                .Property(od => od.detailStatus)
                .HasDefaultValue(0);
            modelBuilder.Entity<OrderDetail>()
                .HasOne<SaleHistory>()
                .WithOne(sh => sh.Detail)
                .HasForeignKey<SaleHistory>(sh => sh.detailId);

        }

    }
}
