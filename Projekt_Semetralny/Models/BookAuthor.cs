namespace Projekt_Semetralny.Models;

public class BookAuthor
{
    public int BookId { get; set; } // Klucz obcy do Book
    public int AuthorId { get; set; } // Klucz obcy do Author

    public Book Book { get; set; }
    public Author Author { get; set; }
}