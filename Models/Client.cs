namespace PFLogistcs.Models
{
  public class Client
  {
    public int ClientId { get; set; }
    public string? Name { get; set; }
    public string? CellPhone { get; set; }
    public int AddressId { get; set; }
    public virtual Address? Adress { get; set; }
  }
}