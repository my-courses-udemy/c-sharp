using first_web_api.Db;
using first_web_api.Entities;
using first_web_api.Filters;
using first_web_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace first_web_api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly AppDbContext _context;
    private ILogger<AuthorsController> _logger;

    private readonly IServiceTask _serviceTask;
    private readonly ServiceTransient _serviceTransient;
    private readonly ServiceScoped _serviceScoped;
    private readonly ServiceSingleton _serviceSingleton;

    public AuthorsController(AppDbContext context, IServiceTask serviceTask,
        ServiceTransient serviceTransient,
        ServiceScoped serviceScoped,
        ServiceSingleton serviceSingleton,
        ILogger<AuthorsController> logger)
    {
        _context = context;
        _serviceTask = serviceTask;
        _serviceTransient = serviceTransient;
        _serviceScoped = serviceScoped;
        _serviceSingleton = serviceSingleton;
        _logger = logger;
    }

    [HttpGet("guid")]
    [ResponseCache(Duration = 10)]
    [ServiceFilter(typeof(MyActionFilter))]
    public ActionResult<Guid> GetGuid()
    {
        return Ok(
            new
            {
                Transient = _serviceTransient.Guid,
                Scoped = _serviceScoped.Guid,
                Singleton = _serviceSingleton.Guid,
                ServiceA_Transient = _serviceTask.GetTransientGuid(),
                ServiceA_Scoped = _serviceTask.GetScopedGuid(),
                ServiceA_Singleton = _serviceTask.GetSingletonGuid()
            });
    }

    [HttpGet]
    [HttpGet("list")]
    [HttpGet("/list")]
    // [Authorize]
    [ServiceFilter(typeof(MyActionFilter))]
    public async Task<ActionResult<List<Author>>> GetAuthors()
    {
        // throw new Exception("Exception from GetAuthors");
        _logger.LogInformation("Getting all authors");
        _logger.LogWarning("Getting all authors by warning");
        var authors = await _context.Authors
            .Include(author => author.Books)
            .ToListAsync();
        return Ok(authors);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Author>> GetAuthor(int id)
    {
        var author = await _context.Authors.FindAsync(id);
        if (author == null)
        {
            return NotFound();
        }

        return Ok(author);
    }

    [HttpGet("{name}/{param:bool=true}")]
    public async Task<ActionResult<Author>> GetAuthor(string name, bool param)
    {
        var author = await _context.Authors.FirstOrDefaultAsync(author => author.Name == name);
        if (author == null)
        {
            return NotFound();
        }

        return Ok(author);
    }

    [HttpGet("first")]
    public async Task<ActionResult<Author>> GetFirstAuthor()
    {
        var author = await _context.Authors.FirstOrDefaultAsync();
        return Ok(author);
    }

    [HttpPost]
    public async Task<ActionResult<Author>> CreateAuthor(Author author)
    {
        var authorExists = await _context.Authors.AnyAsync(a => a.Name == author.Name);
        if (authorExists)
        {
            return BadRequest($"Author already exists with the name {author.Name}");
        }

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