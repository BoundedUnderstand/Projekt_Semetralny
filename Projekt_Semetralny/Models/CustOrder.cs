namespace Projekt_Semetralny.Models;

public class CustOrder
{
    public int OrderId { get; set; } // Klucz główny
    public DateTime OrderDate { get; set; }
    public int CustomerId { get; set; }
    public int ShippingMethodId { get; set; }
    public int DestAddressId { get; set; }

    public Customer Customer { get; set; }
    public ShippingMethod ShippingMethod { get; set; }
    public Address DestinationAddress { get; set; }
    public ICollection<OrderLine> OrderLines { get; set; }
    public ICollection<OrderHistory> OrderHistories { get; set; }
}