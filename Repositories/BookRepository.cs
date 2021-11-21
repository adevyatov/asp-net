using System.Collections.Generic;
using System.Linq;
using WebApi.Models.Dto;

namespace WebApi.Repositories
{
    public class BookRepository : IBookRepository
    {
        /// <summary>
        ///     1.2.2.3 - Статичный список людей
        /// </summary>
        private static List<BookDto> Books { get; } = new()
        {
            new BookDto
            {
                Id = 1,
                Title = "Крыса из нержавеющей стали",
                AuthorId = 1,
                Genre = "Фантастика",
            },
            new BookDto
            {
                Id = 2,
                Title = "Неукротимая планета",
                AuthorId = 1,
                Genre = "Фантастика",
            },
            new BookDto
            {
                Id = 3,
                Title = "Черновик",
                AuthorId = 3,
                Genre = "Фантастика",
            },
            new BookDto
            {
                Id = 4,
                Title = "Алмазный меч, Деревянный меч",
                AuthorId = 2,
                Genre = "Фэнтези",
            },
        };

        private static int LastId { get; set; } = Books.Count;

        public IEnumerable<BookDto> GetAll()
        {
            return Books.ToArray();
        }

        public BookDto? GetById(int id)
        {
            return Books.FirstOrDefault(h => h.Id == id);
        }

        public IEnumerable<BookDto> GetByAuthorId(int authorId)
        {
            return Books.Where(b => b.AuthorId == authorId).ToArray();
        }

        public BookDto Add(BookDto book)
        {
            book.Id = ++LastId;
            Books.Add(book);

            return book;
        }

        public void Remove(BookDto book)
        {
            Books.Remove(book);
        }
    }
}
