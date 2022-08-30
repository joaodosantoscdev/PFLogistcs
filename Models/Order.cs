using System.Collections.ObjectModel;
namespace PFLogistcs.Models
{
    public class Order
    {
        public Order() 
        {
            ItemOrders = new Collection<ItemOrder>();
        }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public ICollection<ItemOrder> ItemOrders { get; set; }
        
        
    }
}