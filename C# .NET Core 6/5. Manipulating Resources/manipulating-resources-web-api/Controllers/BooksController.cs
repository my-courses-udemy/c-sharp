using AutoMapper;
using first_web_api.Db;
using first_web_api.Dto;
using first_web_api.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace first_web_api.Controllers;

[ApiController]
[Route("/api/books")]
public class BooksController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public BooksController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var books = await _context.Books
            .ToListAsync();
        return Ok(_mapper.Map<List<BookDto>>(books));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetBook(int id)
    {
        var book = await _context.Books
            // .Include(book => book.Author)
            // .Include(b => b.Comments)
            .Include(b => b.AuthorBooks)
            .ThenInclude(ab => ab.Author)
            .FirstOrDefaultAsync(book => book.Id == id);
        if (book == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<BookDtoWithAuthors>(book));
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook(CreatedBookDto bookDto)
    {
        var authorsIds = await _context.Authors
            .Where(author => bookDto.AuthorIds.Contains(author.Id))
            .Select(author => author.Id)
            .ToListAsync();

        if (authorsIds.Count != bookDto.AuthorIds.Count)
        {
            return BadRequest();
        }

        var book = _mapper.Map<Book>(bookDto);
        var bookCreated = await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
        // return CreatedAtAction(nameof(GetBook), new { id = bookCreated.Entity.Id },
        //     _mapper.Map<BookDto>(bookCreated.Entity));
        return CreatedAtAction(nameof(GetBook), new { id = bookCreated.Entity.Id },
            _mapper.Map<BookDto>(bookCreated.Entity));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateBook(int id, CreatedBookDto bookDto)
    {
        var book = await _context.Books
            .Include(b => b.AuthorBooks)
            .FirstOrDefaultAsync(book => book.Id == id);
        if (book == null)
        {
            return NotFound();
        }

        var bookUpdated = _mapper.Map(bookDto, book);
        var entityUpdated = _context.Books.Update(bookUpdated);
        await _context.SaveChangesAsync();
        return Ok(_mapper.Map<BookDto>(entityUpdated.Entity));
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> PartiallyUpdateBook(int id,
        JsonPatchDocument<BooktPatchDto> patchDocument)
    {
        var book = await _context.Books
            .FirstOrDefaultAsync(book => book.Id == id);
        if (book == null)
        {
            return NotFound();
        }

        var bookToPatch = _mapper.Map<BooktPatchDto>(book);
        patchDocument.ApplyTo(bookToPatch, ModelState);
        if (!TryValidateModel(bookToPatch))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(bookToPatch, book);
        var entityUpdated = _context.Books.Update(book);
        await _context.SaveChangesAsync();
        return Ok(_mapper.Map<BookDto>(entityUpdated.Entity));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var book = await _context.Books
            .FirstOrDefaultAsync(book => book.Id == id);
        if (book == null)
        {
            return NotFound();
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}