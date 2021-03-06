using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Arguments;
using WebApi.Models.Dto;
using WebApi.Services;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("books")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        ///     1.4.1.1 - Список книг
        ///     2.2.2 - Возможность сделать запрос с сортировкой по автору, имени книги и жанру
        /// </summary>
        [HttpGet]
        public IEnumerable<BookDto> GetBooks([FromQuery] BookListSort sortBy)
        {
            return _bookService.GetBooks(sortBy);
        }

        /// <summary>
        ///     1.4.1.2 - Список всех книг по автору (фильтрация AuthorId).
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
        public BookDto AddBook([FromBody] AddBookViewModel model)
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
