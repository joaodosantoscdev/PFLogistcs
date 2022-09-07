namespace PFLogistcs.Models
{
    public class ItemOrder
    {
        public int Quantity { get; set; }
        public double SalesPrice {get; set;}     
        public int ProductId { get; set; }
        public  Product Product {get; set;}
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}