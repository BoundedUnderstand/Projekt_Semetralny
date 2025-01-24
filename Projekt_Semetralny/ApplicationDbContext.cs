using GravityBookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace Projekt_Semetralny
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}