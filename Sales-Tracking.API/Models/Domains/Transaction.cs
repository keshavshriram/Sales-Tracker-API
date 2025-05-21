using System.ComponentModel.DataAnnotations;

namespace Sales_Tracking.API.Models.Domains
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public string? Action { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
