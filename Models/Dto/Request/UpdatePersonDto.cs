using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Dto.Request
{
    public class UpdatePersonDto : CreatePersonDto
    {
        [Required]
        public int Id { get; set; }

        public override string Name { get; set; } = null!;

        public override string Surname { get; set; } = null!;
    }
}
