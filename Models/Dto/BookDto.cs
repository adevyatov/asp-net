using System.Collections.Generic;

namespace WebApi.Models.Dto
{
    /// <summary>
    ///     1.2.2 - Класс книги
    /// </summary>
    public class BookDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public AuthorDto Author { get; set; } = null!;

        public IEnumerable<GenreDto> Genres { get; set; } = null!;
    }
}
