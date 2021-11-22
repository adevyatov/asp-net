using System.Collections.Generic;

namespace WebApi.Models
{
    /// <summary>
    /// #2 - 2.2 - Модель для таблицы book
    /// </summary>
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public Author Author { get; set; } = null!;

        public int AuthorId { get; set; }

        public IEnumerable<Genre> Genres { get; set; } = null!;

        public IEnumerable<LibraryCard> LibraryCards { get; set; } = null!;
    }
}
