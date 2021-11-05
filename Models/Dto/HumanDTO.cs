using System;

namespace WebApi.Models.Dto
{
    /// <summary>
    ///     1.2.1 - Класс человека
    /// </summary>
    public class HumanDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string? Patronymic { get; set; }

        public string PenName { get; set; } = null!;

        public DateTime Birthday { get; set; }
    }
}