using AutoMapper;
using first_web_api.Db;
using first_web_api.Dto;
using first_web_api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace first_web_api.Controllers;

[ApiController]
[Route("api/books/{bookId:int}/comments")]
public class CommentController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CommentController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetComments(int bookId)
    {
        var book = await _context.Books.FindAsync(bookId);
        if (book == null)
        {
            return NotFound();
        }

        var comments = await GetCommentsAsync(bookId);

        return Ok(_mapper.Map<IEnumerable<CommentDto>>(comments));
    }


    [HttpGet("{commentId:int}")]
    public async Task<IActionResult> GetComment(int commentId, int bookId)
    {
        var book = await _context.Books.FindAsync(bookId);
        if (book == null)
        {
            return NotFound();
        }

        var comments = await GetCommentsAsync(bookId);

        var comment = comments.FirstOrDefault(c => c.Id == commentId);
        if (comment == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<CommentDto>(comment));
    }

    private async Task<List<Comment>> GetCommentsAsync(int bookId)
    {
        var comments = await _context.Comments
            .Where(c => c.BookId == bookId)
            .ToListAsync();
        return comments;
    }

    [HttpPost]
    public async Task<IActionResult> CreateComment(int bookId, CreatedCommentDto createdCommentDto)
    {
        var book = await _context.Books.FindAsync(bookId);
        if (book == null)
        {
            return NotFound();
        }

        var comment = _mapper.Map<Comment>(createdCommentDto);
        comment.Book = book;
        var createdComment = await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetComment),
            new { bookId, commentId = createdComment.Entity.Id },
            _mapper.Map<CommentDto>(createdComment.Entity));
    }

    [HttpPut("{commentId:int}")]
    public async Task<IActionResult> UpdateComment(int bookId, int commentId,
        CreatedCommentDto commentDto)
    {
        var book = await _context.Books.FindAsync(bookId);
        if (book == null)
        {
            return NotFound();
        }

        var comment = await _context.Comments.FindAsync(commentId);
        if (comment == null)
        {
            return NotFound();
        }

        var commentUpdated = _mapper.Map(commentDto, comment);
        await _context.SaveChangesAsync();

        return Ok(_mapper.Map<CommentDto>(commentUpdated));
    }
}