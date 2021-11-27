using System;
using System.Text.Json.Serialization;
using WebApi.Behaviour.Serialization;

namespace WebApi.Models.Dto
{
    public class LibraryCardDto
    {
        public int Id { get; set; }
        public BookDto Book { get; set; } = null!;

        [JsonConverter(typeof(DateConverter))]
        public DateTime Date { get; set; }
    }
}
