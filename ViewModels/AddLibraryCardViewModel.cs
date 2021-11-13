using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels
{
    public class AddLibraryCardViewModel
    {
        [Required]
        public int HumanId { get; set; }

        [Required]
        public int BookId { get; set; }
    }
}
