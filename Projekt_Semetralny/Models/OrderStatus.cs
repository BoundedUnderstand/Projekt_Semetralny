using Projekt_Semetralny.Models;

public class OrderStatus
{
    public int StatusId { get; set; }
    public string StatusValue { get; set; }

    public ICollection<OrderHistory> OrderHistories { get; set; }
}