using System.Collections.Generic;

namespace WebApi.Models.Dto
{
    public class AuthorDto
    {
        public int Id { get; set;  }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? MiddleName { get; set; }

        public IEnumerable<BookDto> Books { get; set; } = null!;
    }
}
