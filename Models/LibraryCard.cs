using System;

namespace WebApi.Models
{
    /// <summary>
    ///     #1. 2.1.1 - Класс LibraryCard
    ///     #2. 2.2 - Модель для таблицы library_card
    /// </summary>
    public class LibraryCard
    {
        public int Id { get; set; }

        public Book Book { get; set; } = null!;
        public int BookId { get; }

        public Person Person { get; set; } = null!;
        public int PersonId { get; set; }

        public DateTime Date { get; set; }
    }
}
