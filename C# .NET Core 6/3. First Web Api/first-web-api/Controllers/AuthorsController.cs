using first_web_api.Db;
using first_web_api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace first_web_api.Controllers;

[ApiController]
[Route("/api/authors")]
public class AuthorsController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthorsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Author>>> GetAuthors()
    {
        var authors = await _context.Authors
            .Include(author => author.Books)
            .ToListAsync();
        return Ok(authors);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Author>> GetAuthor(int id)
    {
        var author = await _context.Authors.FindAsync(id);
        return Ok(author);
    }

    [HttpPost]
    public async Task<ActionResult<Author>> CreateAuthor(Author author)
    {
        var value = await _context.Authors.AddAsync(author);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAuthor), new { id = value.Entity.Id }, value.Entity);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Author>> UpdateAuthor(int id, Author author)
    {
        if (id != author.Id)
        {
            return BadRequest("Id does not match");
        }

        var updated = _context.Authors.Update(author);
        await _context.SaveChangesAsync();
        return Ok(updated.Entity);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Author>> DeleteAuthor(int id)
    {
        var author = await _context.Authors.FindAsync(id);
        if (author == null)
        {
            return NotFound();
        }

        _context.Authors.Remove(author);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}