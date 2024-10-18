using Microsoft.EntityFrameworkCore;

namespace ComisionQA.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime orderDate { get; set; }
        public int orderStatus { get; set; } //0 pendiente, 1 entregado, 2 cancelado
        public Profile profile { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public DateTime? deletedAt { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
        public void updateProperties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(o => o.createdAt)
                .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<Order>()
                .Property(o => o.updatedAt)
                .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<Order>()
                .HasMany<OrderDetail>(o => o.OrderDetails)
                .WithOne(od => od.Order)
                .HasForeignKey(od => od.orderId);
        }
    }
}
