using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Db;
using WebApi.Models.Dto;

namespace WebApi.Controllers
{
    [Route("books")]
    public class BookController : Controller
    {
        /// <summary>
        ///     1.4.1 - Список книг
        /// </summary>
        [HttpGet]
        public IEnumerable<BookDto> GetBooks()
        {
            return Database.Books.ToArray();
        }

        /// <summary>
        ///     1.4.2 - Добавление новой книги
        /// </summary>
        [HttpGet("{authorId}")]
        public IEnumerable<BookDto> GetBooks([FromRoute] int authorId)
        {
            return Database.Books.Where(b => b.Author == authorId).ToArray();
        }
    }
}
