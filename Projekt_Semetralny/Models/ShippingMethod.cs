namespace Projekt_Semetralny.Models;

public class ShippingMethod
{

    public int MethodId { get; set; } // Klucz główny
    public string MethodName { get; set; }
    public decimal Cost { get; set; }

    public ICollection<CustOrder> CustOrders { get; set; } // Relacja do Order
  
}