using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt_Semetralny;

public class AuthorsController : Controller
{
    private readonly ApplicationDbContext _context;

    public AuthorsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Lista autorów
    public async Task<IActionResult> Index()
    {
        var authors = await _context.Authors
            .Include(a => a.BookAuthors)
            .ThenInclude(ba => ba.Book)
            .ToListAsync();

        return View(authors);
    }
}