using System.ComponentModel.DataAnnotations.Schema;

namespace ComisionQA.Models
{
    [Table("inventories")]
    public class Inventory
    {
        public int Id { get; set; }
        public DateTime admissionDate { get; set; }
        public int stock { get; set; }
        public int vehicleModelId { get; set; }
        public VehicleModel VehicleModel { get; set; }
        public int supplierId { get; set; }
        public Supplier Supplier { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public DateTime? deletedAt { get; set; }
    }
}
