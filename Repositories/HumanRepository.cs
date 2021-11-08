using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Db;
using WebApi.Models.Dto;

namespace WebApi.Repositories
{
    public class HumanRepository : IHumanRepository
    {
        private readonly IBookRepository _bookRepository;

        private static List<HumanDto> Humans { get; } = new()
        {
            new HumanDto
            {
                Id = 1,
                Surname = "Максвелл Демпси",
                Name = "Генри",
                Birthday = DateTime.Parse("1925-03-12"),
            },
            new HumanDto
            {
                Id = 2,
                Surname = "Перумов",
                Name = "Николай",
                Patronymic = "Даниилович",
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

        private static int LastId { get; set; } = Humans.Count;

        public HumanRepository(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public HumanDto? GetById(int id)
        {
            return Humans.FirstOrDefault(h => h.Id == id);
        }

        public IEnumerable<HumanDto> GetAll()
        {
            return Humans.ToArray();
        }

        public IEnumerable<HumanDto> GetByQuery(string query)
        {
            return Humans.FindAll(h =>
                h.Name.Contains(query) ||
                h.Surname.Contains(query) ||
                (h.Patronymic ?? "").Contains(query)
            ).ToArray();
        }

        public IEnumerable<HumanDto> GetWriters()
        {
            return
            (
                from h in Humans
                join b in _bookRepository.GetAll() on h.Id equals b.AuthorId
                select h
            ).Distinct();
        }

        public HumanDto Add(HumanDto human)
        {
            human.Id = ++LastId;
            Humans.Add(human);

            return human;
        }

        public void Remove(HumanDto human)
        {
            Humans.Remove(human);
        }
    }
}
