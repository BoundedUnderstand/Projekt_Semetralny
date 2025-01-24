namespace Projekt_Semetralny.Models;

public class Country
{
    public int CountryId { get; set; }
    public string CountryName { get; set; }

    public ICollection<Address> Addresses { get; set; }
}