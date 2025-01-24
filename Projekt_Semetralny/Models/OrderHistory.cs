namespace Projekt_Semetralny.Models;

public class OrderHistory
{
    public int HistoryId { get; set; } // Klucz główny
    public int OrderId { get; set; } // Klucz obcy do CustOrder
    public int StatusId { get; set; }
    public DateTime StatusDate { get; set; }

    public CustOrder Order { get; set; } // Powiązanie z CustOrder
    public OrderStatus Status { get; set; } // Powiązanie z OrderStatus
}