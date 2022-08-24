namespace PFLogistcs.Models
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int ClientId { get; set; }
        public Client? Client {get; set;}
    }
}