using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Db;
using WebApi.Models.Dto;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("books")]
    public class BookController : Controller
    {
        /// <summary>
        ///     1.4.1.1 - Список книг
        /// </summary>
        [HttpGet]
        public IEnumerable<BookDto> GetBooks()
        {
            return Database.Books.ToArray();
        }

        /// <summary>
        ///     1.4.1.2 - Добавление новой книги
        /// </summary>
        [HttpGet("{authorId}")]
        public IEnumerable<BookDto> GetBooks([FromRoute] int authorId)
        {
            return Database.Books.Where(b => b.AuthorId == authorId).ToArray();
        }

        /// <summary>
        ///     1.4.2 - Добавление новой книги
        /// </summary>
        [HttpPost]
        public BookDto AddBook(AddBookViewModel model)
        {
            var id = Database.Books.Count + 1;

            var book = new BookDto
            {
                Id = id,
                Title = model.Title,
                AuthorId = model.AuthorId,
                Genre = model.Genre,
            };

            Database.Books.Add(book);

            return book;
        }

        /// <summary>
        ///     1.4.3 - Удаление книги
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult DeleteBook([FromRoute] int id)
        {
            var book = Database.Books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound();

            // remove book
            Database.Books.Remove(book);

            return Ok();
        }
    }
}
