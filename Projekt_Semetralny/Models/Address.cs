namespace Projekt_Semetralny.Models;

public class Address
{
    public int AddressId { get; set; }
    public string StreetNumber { get; set; }
    public string StreetName { get; set; }
    public string City { get; set; }
    public int CountryId { get; set; }

    public Country Country { get; set; }
    public ICollection<CustOrder> CustOrders { get; set; } // Relacja z Order
    public IEnumerable<CustomerAddress>? CustomerAddresses { get; set; }
}

