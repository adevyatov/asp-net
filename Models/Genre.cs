using System.Collections.Generic;

namespace WebApi.Models
{
    /// <summary>
    /// #2. 2.2 - Модель для таблицы genre
    /// </summary>
    public class Genre
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public IEnumerable<Book> Books { get; set; } = null!;
    }
}
