using System;
using System.Collections.Generic;

namespace WebApi.Models.Dto
{
    public class LibraryCardDto
    {
        public int Id { get; set; }
        public BookDto Book { get; set; } = null!;
        public PersonDto Person { get; set; } = null!;
        public DateTime Date { get; }
        public IEnumerable<LibraryCardDto> LibraryCards { get; set; } = new List<LibraryCardDto>();
    }
}
