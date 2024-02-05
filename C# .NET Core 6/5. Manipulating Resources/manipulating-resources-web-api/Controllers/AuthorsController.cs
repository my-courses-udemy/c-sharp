using AutoMapper;
using first_web_api.Db;
using first_web_api.Dto;
using first_web_api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace first_web_api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly AppDbContext _context;
    private ILogger<AuthorsController> _logger;
    private readonly IMapper _mapper;

    public AuthorsController(AppDbContext context, ILogger<AuthorsController> logger,
        IMapper mapper)
    {
        _context = context;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    [HttpGet("list")]
    [HttpGet("/list")]
    public async Task<IActionResult> GetAuthors()
    {
        var authors = await _context.Authors
            // .Include(author => author.Books)
            .Select(author => _mapper.Map<AuthorDto>(author))
            .ToListAsync();
        return Ok(authors);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAuthor(int id)
    {
        var author = await _context.Authors
            .Include(a => a.AuthorBooks)
            .ThenInclude(ab => ab.Book)
            .FirstOrDefaultAsync(a => a.Id == id);
        if (author == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<AuthorDtoWithBooks>(author));
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetAuthor(string name)
    {
        var authors = await _context.Authors
            .Where(author => author.Name != null && author.Name.Contains(name))
            .Select(author => _mapper.Map<AuthorDto>(author))
            .ToListAsync();

        return Ok(authors);
    }

    [HttpGet("first")]
    public async Task<ActionResult<AuthorDto>> GetFirstAuthor()
    {
        var author = await _context.Authors.FirstOrDefaultAsync();
        return Ok(_mapper.Map<AuthorDto>(author));
    }

    [HttpPost]
    public async Task<ActionResult<AuthorDto>> CreateAuthor(CreatedAuthorDto authorDto)
    {
        var authorExists = await _context.Authors.AnyAsync(a => a.Name == authorDto.Name);
        if (authorExists)
        {
            return BadRequest($"Author already exists with the name {authorDto.Name}");
        }

        var author = _mapper.Map<Author>(authorDto);

        var value = await _context.Authors.AddAsync(author);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAuthor),
            new { id = value.Entity.Id }, _mapper.Map<AuthorDto>(value.Entity));
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<AuthorDto>> UpdateAuthor(int id, CreatedAuthorDto createdAuthorDto)
    {
        var authorExist = await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);
        if (authorExist == null)
        {
            return NotFound();
        }

        var author = _mapper.Map<Author>(createdAuthorDto);
        author.Id = id;

        var updated = _context.Authors.Update(author);
        await _context.SaveChangesAsync();
        return Ok(_mapper.Map<AuthorDto>(updated.Entity));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAuthor(int id)
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