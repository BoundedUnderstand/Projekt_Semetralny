namespace Projekt_Semetralny.Models;

public class OrderLine
{
    public int LineId { get; set; } // Klucz główny
    public int OrderId { get; set; } // Klucz obcy do CustOrder
    public int BookId { get; set; } // Klucz obcy do Book
    public decimal Price { get; set; }

    public CustOrder CustOrder { get; set; } // Powiązanie z CustOrder
    public Book Book { get; set; } // Powiązanie z Book
}