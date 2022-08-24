namespace PFLogistcs.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public double SalesPrice { get; set; }
        public int CategoryId { get; set; }
        public Category? Category  { get; set; } 
    }
}