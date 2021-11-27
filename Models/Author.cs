using System.Collections.Generic;

namespace WebApi.Models
{
    /// <summary>
    /// #2. 2.2 - Модель для таблицы author
    /// </summary>
    public class Author
    {
        public int Id { get; set;  }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? MiddleName { get; set; }

        public IEnumerable<Book> Books { get; set; } = null!;
    }
}
