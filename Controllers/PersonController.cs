using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Exceptions;
using WebApi.Models.Dto;
using WebApi.Models.Dto.Request;
using WebApi.Services;

namespace WebApi.Controllers
{
    /// <summary>
    ///     1.3 - Контроллер отвечающий за человека
    ///  #2. 7.1 - Контроллер пользователя
    /// </summary>
    [ApiController]
    [Route("person")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IBookService _bookService;

        public PersonController(IPersonService personService, IBookService bookService)
        {
            _personService = personService;
            _bookService = bookService;
        }

        /// <summary>
        ///     1.3.1.1 - Список всех людей
        /// </summary>
        [HttpGet]
        public Task<IEnumerable<PersonDto>> Get()
        {
            return _personService.GetPersons();
        }

        /// <summary>
        ///     #2. 7.1.1 - Пользователь может быть добавлен. (POST) (вернуть пользователя)
        /// </summary>
        [HttpPost]
        public PersonDto Create([FromBody] CreatePersonDto person)
        {
            return _personService.Create(person);
        }

        /// <summary>
        ///     #2. 7.1.2 - Информация о пользователе может быть изменена (PUT) (вернуть пользователя)
        /// </summary>
        [HttpPut]
        public PersonDto Update([FromBody] UpdatePersonDto personDto)
        {
            if (_personService.Exist(personDto.Id) == false)
            {
                throw new HttpNotFoundException("Person not found");
            }

            return _personService.Update(personDto);
        }

        /// <summary>
        ///     1.3.3 - Удаление человека
        ///     #2. 7.1.3 - Пользователь может быть удалён по ID (DELETE) (ок или ошибку, если такого id нет)
        /// </summary>
        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (_personService.Exist(id) == false)
            {
                throw new HttpNotFoundException("Пользователь не найден");
            }

            _personService.Delete(id);

            return Ok();
        }

        /// <summary>
        ///     #2. 7.1.4 - Пользователь или пользователи могут быть удалены по ФИО
        /// (не заботясь о том что могут быть полные тёзки. Без пощады.)
        /// (DELETE) Ok - или ошибку, если что-то пошло не так.
        /// </summary>
        [HttpDelete("{fullName}")]
        public async Task<IActionResult> DeleteByFullName([FromRoute] string fullName)
        {
            await _personService.DeleteByFullName(fullName);

            return Ok();
        }

        /// <summary>
        ///     #2. 7.1.5 - Получить список всех взятых пользователем книг (GET) в качестве параметра поиска - ID пользователя.
        /// Полное дерево: Книги - автор - жанр
        /// </summary>
        [HttpGet("books")]
        public Task<IEnumerable<LibraryCardDto>> GetPersonBooks(int id)
        {
            if (_personService.Exist(id) == false)
            {
                throw new HttpNotFoundException("Пользователь не найден");
            }

            return _personService.GetPersonBooks(id);
        }

        /// <summary>
        ///     #2. 7.1.6 - Пользователь может взять книгу (добавить в список книг пользователя книгу) Пользователь + книги
        /// </summary>
        [HttpPost("~/take-book")]
        public async Task<PersonDto> TakeBook([FromBody] TakeBookDto dto)
        {
            if (_personService.Exist(dto.PersonId) == false)
            {
                throw new HttpNotFoundException("Пользователь не найден");
            }

            if (await _bookService.Exist(dto.BookId) == false)
            {
                throw new HttpNotFoundException("Книга не найден");
            }

            await _personService.TakeBook(dto);

            return _personService.GetPerson(dto.PersonId);
        }

        /// <summary>
        ///     #2 7.1.7 - Пользователь может вернуть книгу (удалить из списка книг пользователя книгу) пользователь + книги
        /// </summary>
        [HttpPut("~/give-away-book")]
        public Task<PersonDto> GiveAwayBook(GiveAwayBookDto dto)
        {
            return _personService.GiveAwayBook(dto);
        }
    }
}
