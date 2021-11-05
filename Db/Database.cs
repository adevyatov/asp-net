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
        public static List<HumanDto> Humans { get; set; } = new()
        {
            new HumanDto
            {
                Id = 1,
                Surname = "Максвелл Демпси",
                Name = "Генри",
                PenName = "Гарри Гаррисон",
                Birthday = DateTime.Parse("1925-03-12"),
            },
            new HumanDto
            {
                Id = 2,
                Surname = "Перумов",
                Name = "Николай",
                Patronymic = "Даниилович",
                PenName = "Ник Перумов",
                Birthday = DateTime.Parse("1963-11-21"),
            },
            new HumanDto
            {
                Id = 3,
                Surname = "Лукьяненко",
                Name = "Сергей",
                Patronymic = "Васильевич",
                Birthday = DateTime.Parse("1968-04-11"),
            },
            new HumanDto
            {
                Id = 4,
                Surname = "Иванов",
                Name = "Иван",
                Patronymic = "Иванович",
                Birthday = DateTime.Parse("1975-07-30"),
            },
        };

        public static List<BookDto> Books { get; set; } = new()
        {
            new BookDto
            {
                Id = 1,
                Title = "Крыса из нержавеющей стали",
                Author = 1,
                Genre = "Фантастика",
            },
            new BookDto
            {
                Id = 2,
                Title = "Неукротимая планета",
                Author = 1,
                Genre = "Фантастика",
            },
            new BookDto
            {
                Id = 3,
                Title = "Черновик",
                Author = 3,
                Genre = "Фантастика",
            },
            new BookDto
            {
                Id = 4,
                Title = "Алмазный меч, Деревянный меч",
                Author = 2,
                Genre = "Фэнтези",
            },
        };
    }
}