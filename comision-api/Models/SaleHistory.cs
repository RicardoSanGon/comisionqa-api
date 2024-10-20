using System.ComponentModel.DataAnnotations.Schema;

namespace ComisionQA.Models
{
    [Table("sale_histories")]
    public class SaleHistory
    {
        public int Id { get; set; }
        public DateTime saleDate { get; set; }
        public int quantity { get; set; }
        public float totalAmount{ get; set; }
        public int vehicleId { get; set; }
        public VehicleModel Vehicle { get; set; }
        public int detailId { get; set; }
        public OrderDetail Detail { get; set; }
        public int profileId { get; set; }
        public Profile Profile { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public DateTime? deletedAt { get; set; }
    }
}
