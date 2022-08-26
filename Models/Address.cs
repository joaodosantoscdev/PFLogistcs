namespace PFLogistcs.Models
{
  public class Address
  {
    public int AddressId { get; set; }
    public string? AddressDescription { get; set; }
    public int Number { get; set; }
    public string? District { get; set; }
    public string? City { get; set; }
    public string? ZipCode { get; set; }
    public Client? Client { get; set; }
  }
}