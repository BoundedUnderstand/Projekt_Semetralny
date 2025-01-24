namespace Projekt_Semetralny.Models;

public class Customer
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public ICollection<CustomerAddress> CustomerAddresses { get; set; }
    public ICollection<CustOrder> Orders { get; set; }
}