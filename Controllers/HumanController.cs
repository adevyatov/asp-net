using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Db;
using WebApi.Models.Dto;

namespace WebApi.Controllers
{
    /// <summary>
    /// 1.3 - Контроллер отвечающий за человека
    /// </summary>
    [ApiController]
    public class HumanController
    {
        /// <summary>
        /// 1.3.1 - Список всех людей
        /// </summary>
        [HttpGet("humans")]
        public IEnumerable<HumanDto> Humans()
        {
            return Database.Humans.ToArray();
        }
    }
}