using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<HumanDto> GetHumans()
        {
            return Database.Humans.ToArray();
        }

        /// <summary>
        /// 1.3.2 - Список людей, являющихся писателями
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
    }
}