using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Dto.Request
{
    public class CreateBookDto
    {
        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public CreateAuthorDto Author { get; set; } = null!;

        [Required]
        public IEnumerable<CreateGenreDto> Genres { get; set; } = null!;
    }
}
