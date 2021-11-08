using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Dto;
using WebApi.Services;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    /// <summary>
    ///     1.3 - Контроллер отвечающий за человека
    /// </summary>
    [ApiController]
    [Route("humans")]
    public class HumanController : Controller
    {
        private readonly HumanService _humanService;

        public HumanController(HumanService humanService)
        {
            _humanService = humanService;
        }

        /// <summary>
        ///     1.3.1.1 - Список всех людей
        /// </summary>
        [HttpGet]
        public IEnumerable<HumanDto> GetHumans()
        {
            return _humanService.GetHumans();
        }

        /// <summary>
        ///     1.3.1.2 - Список людей, являющихся писателями
        /// </summary>
        [HttpGet("writers")]
        public IEnumerable<HumanDto> GetWriters()
        {
            return _humanService.GetWriters();
        }

        /// <summary>
        ///     1.3.1.3 - Поиск людей по фамилии/имени/отчеству
        /// </summary>
        [HttpGet("{query}")]
        public IEnumerable<HumanDto> GetHumans([FromRoute] string query)
        {
            return _humanService.GetHumans(query.Trim());
        }

        /// <summary>
        ///     1.3.2 - Добавление нового человека
        /// </summary>
        [HttpPost]
        public HumanDto AddHuman(AddHumanViewModel model)
        {
            return _humanService.Add(model);
        }

        /// <summary>
        ///     1.3.3 - Удаление человека
        /// </summary>
        [HttpDelete("{id:int}")]
        public IActionResult DeleteHuman([FromRoute] int id)
        {
            var result = _humanService.Delete(id);

            if (!result) return NotFound();

            return Ok();
        }
    }
}
