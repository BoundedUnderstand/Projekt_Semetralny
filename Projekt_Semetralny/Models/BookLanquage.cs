namespace Projekt_Semetralny.Models;

public class BookLanguage
{
    public int LanguageId { get; set; }
    public string LanguageCode { get; set; }
    public string LanguageName { get; set; }

    public ICollection<Book> Books { get; set; }
}