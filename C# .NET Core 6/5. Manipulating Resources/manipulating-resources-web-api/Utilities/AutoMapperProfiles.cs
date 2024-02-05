using AutoMapper;
using first_web_api.Dto;
using first_web_api.Entities;

namespace first_web_api.Utilities;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<CreatedAuthorDto, Author>();
        CreateMap<Author, AuthorDto>();
        CreateMap<Author, AuthorDtoWithBooks>()
            .ForMember(authorDto => authorDto.Books,
                opt => opt.MapFrom(MapAuthorDto));

        CreateMap<CreatedBookDto, Book>()
            .ForMember(book => book.AuthorBooks,
                opt
                    => opt.MapFrom(MapAuthorBooks));
        CreateMap<Book, BookDto>();
        CreateMap<Book, BookDtoWithAuthors>()
            .ForMember(bookDto => bookDto.Authors,
                opt => opt.MapFrom(MapBookDto));
        CreateMap<Book, BooktPatchDto>();
        CreateMap<BooktPatchDto, Book>();

        CreateMap<CreatedCommentDto, Comment>();
        CreateMap<Comment, CommentDto>();
    }

    private static List<AuthorBook> MapAuthorBooks(CreatedBookDto bookDto, Book book)
    {
        return bookDto.AuthorIds
            .Select(authorId => new AuthorBook { AuthorId = authorId })
            .ToList();
    }

    private static List<AuthorDto> MapBookDto(Book book, BookDto bookDto)
    {
        return book.AuthorBooks
            .Select(ab => ab.Author)
            .Select(author => new AuthorDto
            {
                Id = author!.Id,
                Name = author.Name
            })
            .ToList();
    }

    private static List<BookDto> MapAuthorDto(Author author, AuthorDto authorDto)
    {
        return author.AuthorBooks
            .Select(ab => ab.Book)
            .Select(book => new BookDto
            {
                Id = book!.Id,
                Title = book.Title
            })
            .ToList();
    }
}