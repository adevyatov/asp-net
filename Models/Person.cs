using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    /// <summary>
    /// #2. 2.2 - Модель для таблицы person
    /// </summary>
    public class Person
    {
        public int Id { get; set; }

        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;

        public string? Patronymic { get; set; }

        public DateTime? Birthday { get; set; }

        public IEnumerable<LibraryCard> LibraryCards { get; set; } = new List<LibraryCard>();
    }
}
