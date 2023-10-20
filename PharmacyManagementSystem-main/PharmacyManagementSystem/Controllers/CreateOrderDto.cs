namespace PharmacyManagementSystem.Controllers
{
    public class CreateOrderDto
    {



        //-----------------------------------------------------------------

        public decimal total { get; set; }

        //-----------------------------------------------------------------

        public int UserId { get; set; }


        //-----------------------------------------------------------------
        public DateTime pickup_date { get; set; }

    }
}
