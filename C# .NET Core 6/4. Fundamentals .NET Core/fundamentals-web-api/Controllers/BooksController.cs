using first_web_api.Db;
using first_web_api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace first_web_api.Controllers;

[ApiController]
[Route("/api/books")]
public class BooksController : ControllerBase
{
    private readonly AppDbContext _context;

    public BooksController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetBook(int id)
    {
        var book = await _context.Books
            .Include(book => book.Author)
            .FirstOrDefaultAsync(book => book.Id == id);
        if (book == null)
        {
            return NotFound();
        }

        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook(Book book)
    {
        var author = await _context.Authors.FindAsync(book.AuthorId);
        if (author == null)
        {
            return BadRequest("Author does not exist");
        }

        var bookCreated = await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetBook), new { id = bookCreated.Entity.Id },
            bookCreated.Entity);
    }
}