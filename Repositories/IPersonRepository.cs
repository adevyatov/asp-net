using System.Collections.Generic;
using WebApi.Models;
using WebApi.Models.Dto;

namespace WebApi.Repositories
{
    public interface IPersonRepository
    {
        public Person? GetById(int id);

        public IEnumerable<Person> GetAll();

        public IEnumerable<Person> GetByQuery(string query);

        public IEnumerable<Person> GetWriters();

        public Person Add(Person person);

        public void Remove(Person person);
    }
}
