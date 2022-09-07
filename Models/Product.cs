namespace PFLogistcs.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public char Size { get; set; }
        
        public int CategoryId { get; set; }
        public Category Category  { get; set; }
        public virtual ICollection<ItemOrder> ItemOrders { get; set; }
    }
}