using System;
using System.Collections.Generic;
using WebApi.Models.Dto;

namespace WebApi.Db
{
    /// <summary>
    ///     1.2.3 - Список людей и книг
    /// </summary>
    public static class Database
    {
        public static List<BookDto> Books { get; set; } = new()
        {
            new BookDto
            {
                Id = 1,
                Title = "Крыса из нержавеющей стали",
                AuthorId = 1,
                Genre = "Фантастика",
            },
            new BookDto
            {
                Id = 2,
                Title = "Неукротимая планета",
                AuthorId = 1,
                Genre = "Фантастика",
            },
            new BookDto
            {
                Id = 3,
                Title = "Черновик",
                AuthorId = 3,
                Genre = "Фантастика",
            },
            new BookDto
            {
                Id = 4,
                Title = "Алмазный меч, Деревянный меч",
                AuthorId = 2,
                Genre = "Фэнтези",
            },
        };
    }
}
