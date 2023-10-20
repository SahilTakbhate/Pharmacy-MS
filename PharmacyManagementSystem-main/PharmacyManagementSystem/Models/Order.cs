using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace PharmacyManagementSystem.Models
{
    public class Order
    {
        [Key]
        public int order_id { get; set; }

        //-----------------------------------------------------------------
        [Required]
        public int order_no { get; set; }

        //-----------------------------------------------------------------
        [Required]
        public decimal total { get; set; }

        //-----------------------------------------------------------------
        [JsonIgnore]
        public User user { get; set; }
        public int UserId { get; set; }


        //-----------------------------------------------------------------
        public DateTime pickup_date { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }


        public Order() { }

    }
}