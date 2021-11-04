using System;

namespace WebApi.Models.Dto
{
    /// <summary>
    ///     1.2.1 - Класс человека
    /// </summary>
    public class HumanDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string PenName { get; set; }

        public DateTime Birthday { get; set; }
    }
}