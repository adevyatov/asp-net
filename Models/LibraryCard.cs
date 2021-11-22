using System;

namespace WebApi.Models
{
    /// <summary>
    ///     #1 - 2.1.1 - Класс LibraryCard
    ///     #2 - 2.2 - Модель для таблицы library_card
    /// </summary>
    public class LibraryCard
    {
        // public LibraryCard(HumanDto human, BookDto book)
        // {
        //     HumanId = human.Id;
        //     BookId = book.Id;
        //     Date = DateTimeOffset.Now;
        // }

        public int Id { get; set; }

        public Book Book { get; } = null!;
        public int BookId { get; }

        public Person Person { get; } = null!;
        public int PersonId { get; }

        public DateTime Date { get; }
    }
}
