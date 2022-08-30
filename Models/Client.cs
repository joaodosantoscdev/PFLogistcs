using System.Collections.ObjectModel;
namespace PFLogistcs.Models
{
  public class Client
  {
    public Client()
    {
      ItemOrders = new Collection<ItemOrder>();
    }

    public int ClientId { get; set; }
    public string Name { get; set; }
    public string CellPhone { get; set; }
    public int AddressId { get; set; }
    public virtual Address Address { get; set; }
    public ICollection<ItemOrder> ItemOrders { get; set; }

  }
}