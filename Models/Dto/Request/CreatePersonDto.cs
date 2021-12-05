using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WebApi.Behaviour.Serialization;

namespace WebApi.Models.Dto.Request
{
    public class CreatePersonDto
    {
        [Required]
        public virtual string Name { get; set; } = null!;

        [Required]
        public virtual string Surname { get; set; } = null!;

        public string? Patronymic { get; set; }

        [JsonConverter(typeof(DateConverter))]
        public DateTime Birthday { get; set; }
    }
}
