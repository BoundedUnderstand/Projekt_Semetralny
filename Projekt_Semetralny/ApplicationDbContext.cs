using Microsoft.EntityFrameworkCore;
using Projekt_Semetralny.Models;

namespace Projekt_Semetralny;

public sealed class ApplicationDbContext : DbContext
{
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookLanguage> BookLanguages { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerAddress> CustomerAddresses { get; set; }
    public DbSet<CustOrder> CustOrders { get; set; }
    public DbSet<OrderHistory> OrderHistories { get; set; }
    public DbSet<OrderLine> OrderLines { get; set; }
    public DbSet<OrderStatus> OrderStatuses { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<ShippingMethod> ShippingMethods { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:\\data\\gravity.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Book>()
        .ToTable("book") // Mapowanie encji do tabeli "book"
        .HasKey(b => b.BookId); // Klucz główny

    modelBuilder.Entity<Book>()
        .Property(b => b.BookId)
        .HasColumnName("book_id"); // Mapowanie klucza głównego

    modelBuilder.Entity<Book>()
        .Property(b => b.Title)
        .HasColumnName("title"); // Mapowanie kolumny tytułu

    modelBuilder.Entity<Book>()
        .Property(b => b.ISBN13)
        .HasColumnName("isbn13"); // Mapowanie kolumny ISBN

    modelBuilder.Entity<Book>()
        .Property(b => b.LanguageId)
        .HasColumnName("language_id"); // Mapowanie klucza obcego do BookLanguage

    modelBuilder.Entity<Book>()
        .Property(b => b.PublisherId)
        .HasColumnName("publisher_id"); // Mapowanie klucza obcego do Publisher

    modelBuilder.Entity<Book>()
        .Property(b => b.NumPages)
        .HasColumnName("num_pages"); // Mapowanie kolumny liczby stron

    modelBuilder.Entity<Book>()
        .Property(b => b.PublicationDate)
        .HasColumnName("publication_date"); // Mapowanie kolumny daty publikacji


    // -----------------------
    // Author
    // -----------------------
    modelBuilder.Entity<Author>()
        .ToTable("author") // Mapowanie encji do tabeli "author"
        .HasKey(a => a.AuthorId); // Klucz główny

    modelBuilder.Entity<Author>()
        .Property(a => a.AuthorId)
        .HasColumnName("author_id"); // Mapowanie kolumny klucza głównego

    modelBuilder.Entity<Author>()
        .Property(a => a.AuthorName)
        .HasColumnName("author_name");

    // -----------------------
    // BookAuthor
    // -----------------------
    modelBuilder.Entity<BookAuthor>()
        .ToTable("book_author") // Mapowanie encji do tabeli "book_author"
        .HasKey(ba => new { ba.BookId, ba.AuthorId }); // Klucz złożony

    modelBuilder.Entity<BookAuthor>()
        .Property(ba => ba.BookId)
        .HasColumnName("book_id"); // Nazwa kolumny w tabeli

    modelBuilder.Entity<BookAuthor>()
        .Property(ba => ba.AuthorId)
        .HasColumnName("author_id"); // Mapowanie do nazwy kolumny w bazie danych

    modelBuilder.Entity<BookAuthor>()
        .HasOne(ba => ba.Book)
        .WithMany(b => b.BookAuthors)
        .HasForeignKey(ba => ba.BookId);

    modelBuilder.Entity<BookAuthor>()
        .HasOne(ba => ba.Author)
        .WithMany(a => a.BookAuthors)
        .HasForeignKey(ba => ba.AuthorId);

    // -----------------------
    // Publisher
    // -----------------------
    modelBuilder.Entity<Publisher>()
        .ToTable("publisher") // Mapowanie encji do tabeli "publisher"
        .HasKey(p => p.PublisherId); // Klucz główny

    // -----------------------
    // Country
    // -----------------------
    modelBuilder.Entity<Country>()
        .ToTable("country") // Mapowanie encji do tabeli "country"
        .HasKey(c => c.CountryId); // Klucz główny

    // -----------------------
    // Address
    // -----------------------
    modelBuilder.Entity<Address>()
        .ToTable("address") // Mapowanie encji do tabeli "address"
        .HasKey(a => a.AddressId); // Klucz główny

    modelBuilder.Entity<Address>()
        .HasOne(a => a.Country)
        .WithMany(c => c.Addresses)
        .HasForeignKey(a => a.CountryId);

    // -----------------------
    // Customer
    // -----------------------
    modelBuilder.Entity<Customer>()
        .ToTable("customer") // Mapowanie encji do tabeli "customer"
        .HasKey(c => c.CustomerId); // Klucz główny

    // -----------------------
    // CustOrder
    // -----------------------
    modelBuilder.Entity<CustOrder>()
        .ToTable("cust_order") // Mapowanie encji do tabeli "cust_order"
        .HasKey(o => o.OrderId); // Klucz główny

    modelBuilder.Entity<CustOrder>()
        .HasOne(o => o.Customer)
        .WithMany(c => c.Orders) // Relacja z Customer
        .HasForeignKey(o => o.CustomerId);

    modelBuilder.Entity<CustOrder>()
        .HasOne(o => o.ShippingMethod)
        .WithMany(s => s.CustOrders) // Relacja z ShippingMethod
        .HasForeignKey(o => o.ShippingMethodId);

    modelBuilder.Entity<CustOrder>()
        .HasOne(o => o.DestinationAddress)
        .WithMany(a => a.CustOrders) // Relacja z Address
        .HasForeignKey(o => o.DestAddressId);

    // -----------------------
    // OrderLine
    // -----------------------
    modelBuilder.Entity<OrderLine>()
        .ToTable("order_line") // Mapowanie encji do tabeli "orderline"
        .HasKey(ol => ol.LineId); // Klucz główny

    modelBuilder.Entity<OrderLine>()
        .HasOne(ol => ol.CustOrder) // Powiązanie z CustOrder
        .WithMany(o => o.OrderLines) // Właściwość w CustOrder
        .HasForeignKey(ol => ol.OrderId); // Klucz obcy

    modelBuilder.Entity<OrderLine>()
        .HasOne(ol => ol.Book)
        .WithMany(b => b.OrderLines)
        .HasForeignKey(ol => ol.BookId);
    // -----------------------
    // OrderStatus
    // -----------------------
    modelBuilder.Entity<OrderStatus>()
        .ToTable("order_status") // Mapowanie encji do tabeli "orderstatus"
        .HasKey(os => os.StatusId); // Klucz główny
    // -----------------------
    // OrderHistory
    // -----------------------
    modelBuilder.Entity<OrderHistory>()
        .ToTable("order_history") // Mapowanie encji do tabeli "orderhistory"
        .HasKey(oh => oh.HistoryId); // Klucz główny

    modelBuilder.Entity<OrderHistory>()
        .HasOne(oh => oh.Order) // Powiązanie z CustOrder
        .WithMany(o => o.OrderHistories) // Właściwość w CustOrder
        .HasForeignKey(oh => oh.OrderId); // Klucz obcy

    modelBuilder.Entity<OrderHistory>()
        .HasOne(oh => oh.Status)
        .WithMany()
        .HasForeignKey(oh => oh.StatusId);

    // -----------------------
    // BookLanguage
    // -----------------------
    modelBuilder.Entity<BookLanguage>()
        .ToTable("book_language") // Mapowanie encji do tabeli "booklanguage"
        .HasKey(bl => bl.LanguageId); // Klucz główny
    
    // -----------------------
    // CustomerAddress
    // -----------------------
    modelBuilder.Entity<CustomerAddress>()
        .ToTable("customer_address") // Mapowanie encji do tabeli "customeraddress"
        .HasKey(ca => new { ca.CustomerId, ca.AddressId }); // Klucz złożony

    modelBuilder.Entity<CustomerAddress>()
        .HasOne(ca => ca.Customer)
        .WithMany(c => c.CustomerAddresses)
        .HasForeignKey(ca => ca.CustomerId);

    modelBuilder.Entity<CustomerAddress>()
        .HasOne(ca => ca.Address)
        .WithMany(a => a.CustomerAddresses)
        .HasForeignKey(ca => ca.AddressId);
    // -----------------------
    // ShippingMethod
    // -----------------------
    modelBuilder.Entity<ShippingMethod>()
        .ToTable("shipping_method") // Mapowanie encji do tabeli "shippingmethod"
        .HasKey(sm => sm.MethodId); // Klucz główny
}










    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        try
        {
            Database.EnsureCreated(); // Sprawdza, czy baza istnieje i jest poprawna
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd połączenia z bazą danych: {ex.Message}");
        }
    }


}

