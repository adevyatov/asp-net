using System.Collections.Generic;

namespace WebApi.Models.Dto.Request
{
    public class UpdateBookGenreDto
    {
        public int BookId { get; set; }

        public IEnumerable<int> GenreIds { get; set; } = null!;
    }
}
