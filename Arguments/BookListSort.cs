using System;

namespace WebApi.Arguments
{
    /// <summary>
    ///     2.2.2 - Класс DTO для передачи аргументов из конструктора в сервис
    /// </summary>
    public class BookListSort
    {
        public string? OrderBy { get; set; }

        public string Direction { get; set; } = "desc";
    }
}
