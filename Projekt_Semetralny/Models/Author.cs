namespace Projekt_Semetralny.Models;

public class Author
{
    public int AuthorId { get; set; } // Klucz główny
    public string AuthorName { get; set; } // Nazwa autora

    public ICollection<BookAuthor> BookAuthors { get; set; } // Relacja z BookAuthor
}