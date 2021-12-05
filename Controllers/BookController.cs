using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Exceptions;
using WebApi.Models.Dto;
using WebApi.Models.Dto.Request;
using WebApi.Services;

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
        ///     #1. 1.4.1.1 - Список книг
        ///     #1. 2.2.2 - Возможность сделать запрос с сортировкой по автору, имени книги и жанру
        /// </summary>
        [HttpGet("")]
        public Task<IEnumerable<BookDto>> GetBooks([FromQuery] OrderDto dto)
        {
            return _bookService.GetBooks(dto);
        }

        /// <summary>
        ///     #1. 1.4.1.2 - Список всех книг по автору (фильтрация AuthorId).
        /// </summary>
        [HttpGet("{authorId:int}")]
        public Task<IEnumerable<BookDto>> GetBooks([FromRoute] int authorId)
        {
            return _bookService.GetBooks(authorId);
        }

        [HttpGet("by-author-name")]
        public Task<List<BookDto>> GetBooksByAuthorName([FromQuery] AuthorNameDto dto)
        {
            return _bookService.GetBooksByAuthorName(dto);
        }

        /// <summary>
        ///     #1. 1.4.2 - Добавление новой книги
        ///     #2. 7.2.1 - Книга может быть добавлена (POST) (вместе с автором и жанром) книга + автор + жанр
        /// </summary>
        [HttpPost]
        public Task<BookDto> AddBook([FromBody] CreateBookDto model)
        {
            return _bookService.Add(model);
        }

        /// <summary>
        ///     #1. 1.4.3 - Удаление книги
        ///     #2. 7.2.2 - Книга может быть удалена из списка библиотеки (но только если она не у пользователя) по ID
        ///                 (ок, или ошибка, что книга у пользователя)
        /// </summary>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            if (await _bookService.Exist(id) == false)
                throw new HttpNotFoundException("Book with given id not found");

            return await _bookService.Delete(id)
                ? Ok()
                : throw new HttpConstraintException("Someone already has that book at this moment");
        }

        /// <summary>
        ///     #2. 7.2.3 - Книге можно присвоить новый жанр, или удалить один из имеющихся
        ///                 (PUT с телом.На вход сущность Book или её Dto) При добавлении или удалении вы должны
        ///                 просто либо добавлять запись, либо удалять из списка жанров.
        ///                 Каскадно удалять все жанры и книги с таким жанром нельзя! Книга + жанр + автор
        /// </summary>
        [HttpPut("change-genres")]
        public async Task<BookDto> ChangeGenre([FromBody] UpdateBookGenreDto dto)
        {
            if (await _bookService.Exist(dto.BookId) == false)
                throw new HttpNotFoundException("Book with given id not found");

            return await _bookService.UpdateGenres(dto);
        }

        /// <summary>
        ///     #2. 7.2.5 - Можно получить список книг по жанру. Книга + жанр + автор
        /// </summary>
        [HttpGet("by-genre/{genreId:int}")]
        public Task<List<BookDto>> GetBooksByGenre(int genreId)
        {
            return _bookService.GetBooksByGenreId(genreId);
        }
    }
}
