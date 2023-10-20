using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PharmacyManagementSystem.Models
{
    public class Sales
    {
        [Key]
        public int sales_id { get; set; }

        [JsonIgnore]
        public Order order { get; set; }
        public int OrderId { get; set; }

        [Required]
        public DateTime date_time { get; set; }

        [Required]
        public decimal paid_amount { get; set; }

        [Required]
        public decimal balance { get; set; }
    }
}
