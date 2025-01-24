namespace Projekt_Semetralny.Models;

public class Book
{
    public int BookId { get; set; } // Klucz główny
    public string Title { get; set; }
    public string ISBN13 { get; set; }
    public int LanguageId { get; set; }
    public int NumPages { get; set; } // Liczba stron
    public DateTime PublicationDate { get; set; } // Data publikacji
    public int PublisherId { get; set; }

    public BookLanguage Language { get; set; }
    public Publisher Publisher { get; set; }
    public ICollection<BookAuthor> BookAuthors { get; set; }
    public ICollection<OrderLine> OrderLines { get; set; }
}