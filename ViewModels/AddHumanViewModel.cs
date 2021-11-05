using System;

namespace WebApi.ViewModels
{
    public class AddHumanViewModel
    {
        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string? Patronymic { get; set; }

        public DateTime Birthday { get; set; }
    }
}
