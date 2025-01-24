using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt_Semetralny.Models;

namespace Projekt_Semetralny.Controllers;

public class BooksController(ApplicationDbContext context) : Controller
{
    // GET: Books
    public async Task<IActionResult> Index()
    {
        var books = await context.Books
            .Include(b => b.BookAuthors)
            .ThenInclude(ba => ba.Author)
            .ToListAsync();

        return View(books);
    }

    // GET: Books/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var book = await context.Books
            .Include(b => b.BookAuthors)
            .ThenInclude(ba => ba.Author)
            .FirstOrDefaultAsync(b => b.BookId == id);

        if (book == null)
        {
            return NotFound();
        }

        return View(book);
    }

    // GET: Books/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Books/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("BookId,Title,ISBN13,LanguageId,NumPages,PublicationDate,PublisherId")] Book book)
    {
        if (ModelState.IsValid)
        {
            context.Add(book);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(book);
    }

    private IActionResult View(Book viewName)
    {
        throw new NotImplementedException();
    }

    // GET: Books/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var book = await context.Books.FindAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        return View(book);
    }

    // POST: Books/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("BookId,Title,ISBN13,LanguageId,NumPages,PublicationDate,PublisherId")] Book book)
    {
        if (id != book.BookId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                context.Update(book);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(book.BookId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(book);
    }

    // GET: Books/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var book = await context.Books
            .FirstOrDefaultAsync(b => b.BookId == id);

        if (book == null)
        {
            return NotFound();
        }

        return View(book);
    }

    // POST: Books/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var book = await context.Books.FindAsync(id);

        if (book != null)
        {
            context.Books.Remove(book);
            await context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private bool BookExists(int id)
    {
        return context.Books.Any(e => e.BookId == id);
    }
}