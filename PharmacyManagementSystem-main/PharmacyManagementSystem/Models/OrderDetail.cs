using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PharmacyManagementSystem.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }

        [JsonIgnore]
        public Order order { get; set; }
        public int OrderId { get; set; }

        [JsonIgnore]
        public Drug drug { get; set; }
        public int DrugId { get; set; }

        [Required]
        public int drug_quantity { get; set; }

        [Required]
        public decimal sub_total { get; set; }


    }
}
