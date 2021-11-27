using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Dto.Request
{
    public class TakeBookDto
    {
        [Required]
        public int PersonId { get; set; }

        [Required]
        public int BookId { get; set; }
    }
}
