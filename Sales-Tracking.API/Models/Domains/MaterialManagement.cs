using System.ComponentModel.DataAnnotations;

namespace Sales_Tracking.API.Models.Domains
{
    public class MaterialManagement
    {

        [Key]
        public int Id { get; set; }
        public int? productId { get; set; }
        public string? Action { get; set; }
        public int Quantity { get; set; }
        public double TotalAmount { get; set; }
        public double perProductRate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsRecordDeleted { get; set; }
    }
}
