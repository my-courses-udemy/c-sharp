namespace first_web_api.Dto;

public class BookDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public DateTime? PublishedOn { get; set; }
}

internal class BookDtoWithAuthors : BookDto
{
    public List<AuthorDto> Authors { get; set; } = [];
}