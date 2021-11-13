using System;
using WebApi.Models.Dto;

namespace WebApi.Models
{
    /// <summary>
    ///     2.1.1 - Класс LibraryCard
    /// </summary>
    public class LibraryCard
    {
        public LibraryCard(HumanDto human, BookDto book)
        {
            Id = Guid.NewGuid();
            HumanId = human.Id;
            BookId = book.Id;
            Date = DateTimeOffset.Now;
        }

        public Guid Id { get; }

        public int HumanId { get; }

        public int BookId { get; }

        public DateTimeOffset Date { get; }
    }
}
