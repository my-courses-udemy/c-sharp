namespace first_web_api.Dto;

public class AuthorDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

internal class AuthorDtoWithBooks : AuthorDto
{
    public List<BookDto> Books { get; set; } = [];
}