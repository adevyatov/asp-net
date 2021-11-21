using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels
{
    public class AddBookViewModel
    {
        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public int AuthorId { get; set; }

        [Required]
        public string Genre { get; set; } = null!;
    }
}
