namespace WebApi.Models.Dto
{
    /// <summary>
    ///     1.2.2 - Класс книги
    /// </summary>
    public class BookDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public int AuthorId { get; set; }

        public string Genre { get; set; } = null!;
    }
}
