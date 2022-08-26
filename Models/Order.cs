namespace PFLogistcs.Models
{
    public class Order
    {
        public int OrderNumberId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}