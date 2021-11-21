using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels
{
    public class AddHumanViewModel
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Surname { get; set; } = null!;

        public string? Patronymic { get; set; }

        [Required]
        public DateTime Birthday { get; set; }
    }
}
