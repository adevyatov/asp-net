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
                Surname = "Максвелл Демпси",
                Name = "Генри",
                PenName = "Гарри Гаррисон",
                Birthday = DateTime.Parse("1925-03-12"),
            },
            new HumanDto
            {
                Surname = "Перумов",
                Name = "Николай",
                Patronymic = "Даниилович",
                PenName = "Ник Перумов",
                Birthday = DateTime.Parse("1963-11-21"),
            },
            new HumanDto
            {
                Surname = "Лукьяненко",
                Name = "Сергей",
                Patronymic = "Васильевич",
                Birthday = DateTime.Parse("1968-04-11"),
            },
            new HumanDto
            {
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
                Title = "Крыса из нержавеющей стали",
                Author = "Гарри Гаррисон",
                Genre = "Фантастика",
            },
            new BookDto
            {
                Title = "Неукротимая планета",
                Author = "Гарри Гаррисон",
                Genre = "Фантастика",
            },
            new BookDto
            {
                Title = "Черновик",
                Author = "Сергей Лукьяненко",
                Genre = "Фантастика",
            },
            new BookDto
            {
                Title = "Алмазный меч, Деревянный меч",
                Author = "Ник Перумов",
                Genre = "Фэнтези",
            },
        };
    }
}