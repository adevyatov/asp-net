using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IBookRepository _bookRepository;

        /// <summary>
        ///     1.2.2.3 - Статичный список книг
        /// </summary>
        private static List<Person> Humans { get; } = new()
        {
        };

        private static int LastId { get; set; } = Humans.Count;

        public PersonRepository(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Person? GetById(int id)
        {
            return Humans.FirstOrDefault(h => h.Id == id);
        }

        public IEnumerable<Person> GetAll()
        {
            return Humans.ToArray();
        }

        public IEnumerable<Person> GetByQuery(string query)
        {
            return Humans.FindAll(h =>
                h.Name.Contains(query) ||
                h.Surname.Contains(query) ||
                (h.Patronymic ?? "").Contains(query)
            ).ToArray();
        }

        public IEnumerable<Person> GetWriters()
        {
            throw new Exception("Not implemented");
            // return
            // (
            //     from h in Humans
            //     join b in _bookRepository.GetAll() on h.Id equals b.AuthorId
            //     select h
            // ).Distinct();
        }

        public Person Add(Person person)
        {
            person.Id = ++LastId;
            Humans.Add(person);

            return person;
        }

        public void Remove(Person person)
        {
            Humans.Remove(person);
        }
    }
}
