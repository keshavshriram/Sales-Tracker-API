using System.ComponentModel.DataAnnotations;

namespace Sales_Tracking.API.Models.Domains
{
    public class FormManagement
    {
        [Key]
        public int productId { get; set; }
        public string? ProductName { get; set; }
        public string? UnitOfMeasure { get; set; }
        public bool IsRecordDeleted { get; set; }

    }
}
