using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebApi.Behaviour.Serialization;

namespace WebApi.Models.Dto
{
    /// <summary>
    ///     1.2.1 - Класс человека
    /// </summary>
    public class PersonDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string? Patronymic { get; set; }

        [JsonConverter(typeof(DateConverter))]
        public DateTime Birthday { get; set; }

        public IEnumerable<LibraryCardDto> LibraryCards { get; set; } = null!;
    }
}
