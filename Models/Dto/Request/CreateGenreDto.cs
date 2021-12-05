using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Dto.Request
{
    public class CreateGenreDto
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
