using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComisionQA.Models
{
    [Table("suppliers")]
    public class Supplier
    {
        public int Id { get; set; }
        public string supplierName { get; set; }
        public string supplierEmail{ get; set; }
        public string supplierPhone { get; set; }
        public bool? status { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public DateTime? deletedAt { get; set; }
        public List<Inventory> Inventories { get; set; }

        public void updatePropeties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>()
                .Property(s => s.createdAt)
                .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<Supplier>()
                .Property(s => s.updatedAt)
                .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<Supplier>()
                .Property(s => s.status)
                .HasDefaultValue(true);

            modelBuilder.Entity<Supplier>()
                .HasMany<Inventory>(s => s.Inventories)
                .WithOne(i => i.Supplier)
                .HasForeignKey(i => i.supplierId);

        }
    }
}
