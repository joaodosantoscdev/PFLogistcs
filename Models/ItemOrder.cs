namespace PFLogistcs.Models
{
    public class ItemOrder
    {
        public int ProductId { get; set; }
        public int OrderNumber { get; set; }
        public int Quantity { get; set; }
        public double SalesPrice {get; set;}     
    }
}