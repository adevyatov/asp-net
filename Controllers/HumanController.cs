using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Db;
using WebApi.Models.Dto;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    /// <summary>
    ///     1.3 - Контроллер отвечающий за человека
    /// </summary>
    [ApiController]
    public class HumanController : Controller
    {
        /// <summary>
        ///     1.3.1.1 - Список всех людей
        /// </summary>
        [HttpGet("humans")]
        public IEnumerable<HumanDto> GetHumans()
        {
            return Database.Humans.ToArray();
        }

        /// <summary>
        ///     1.3.1.2 - Список людей, являющихся писателями
        /// </summary>
        [HttpGet("humans/writers")]
        public IEnumerable<HumanDto> GetWriters()
        {
            return
            (
                from h in Database.Humans
                join b in Database.Books on h.Id equals b.Author
                select h
            ).Distinct();
        }

        /// <summary>
        ///     1.3.1.3 - Поиск людей по фамилии/имени/отчеству
        /// </summary>
        [HttpGet("humans/{query}")]
        public IEnumerable<HumanDto> GetHumans([FromRoute] string query)
        {
            var q = query.Trim();

            return Database.Humans
                .FindAll(h =>
                    h.Name.Contains(q) ||
                    h.Surname.Contains(q) ||
                    (h.Patronymic ?? "").Contains(q)
                ).ToArray();
        }

        /// <summary>
        ///     1.3.2 - Добавление нового человека
        /// </summary>
        [HttpPost("humans")]
        public HumanDto AddHuman(AddHumanViewModel model)
        {
            var id = Database.Humans.Count + 1;

            var human = new HumanDto
            {
                Id = id,
                Name = model.Name,
                Surname = model.Surname,
                Patronymic = model.Patronymic,
                Birthday = model.Birthday,
            };

            Database.Humans.Add(human);

            return human;
        }

        /// <summary>
        ///     1.3.3 - Добавление нового человека
        /// </summary>
        [HttpDelete("humans/{id}")]
        public IActionResult DeleteHuman([FromRoute] int id)
        {
            var human = Database.Humans.FirstOrDefault(h => h.Id == id);
            if (human == null)
            {
                return this.NotFound();
            }

            // remove author's books
            Database.Books.RemoveAll(b => b.Author == id);

            return this.Ok();
        }
    }
}
