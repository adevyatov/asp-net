using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Dto;
using WebApi.Services;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("books")]
    public class BookController : Controller
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        ///     1.4.1.1 - Список книг
        /// </summary>
        [HttpGet]
        public IEnumerable<BookDto> GetBooks()
        {
            return _bookService.GetBooks();
        }

        /// <summary>
        ///     1.4.1.2 - Добавление новой книги
        /// </summary>
        [HttpGet("{authorId:int}")]
        public IEnumerable<BookDto> GetBooks([FromRoute] int authorId)
        {
            return _bookService.GetBooks(authorId);
        }

        /// <summary>
        ///     1.4.2 - Добавление новой книги
        /// </summary>
        [HttpPost]
        public BookDto AddBook(AddBookViewModel model)
        {
            return _bookService.Add(model);
        }

        /// <summary>
        ///     1.4.3 - Удаление книги
        /// </summary>
        [HttpDelete("{id:int}")]
        public IActionResult DeleteBook([FromRoute] int id)
        {
            return _bookService.Delete(id) ? Ok() : NotFound();
        }
    }
}
