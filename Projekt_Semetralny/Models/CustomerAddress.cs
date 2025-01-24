namespace Projekt_Semetralny.Models;

public class CustomerAddress
{
    public int CustomerId { get; set; } // Klucz obcy do Customer
    public int AddressId { get; set; } // Klucz obcy do Address
    public Customer Customer { get; set; }
    public Address Address { get; set; }
}
