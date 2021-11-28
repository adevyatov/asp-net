using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Dto.Request
{
    public class CreateAuthorDto
    {
        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        public string? MiddleName { get; set; }
    }
}
