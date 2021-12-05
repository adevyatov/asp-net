using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Models.Dto;

namespace WebApi.Repositories
{
    public interface IPersonRepository
    {
        public Person? GetById(int id);

        public Task<List<Person>> GetAll();

        public Task<List<Person>> GetByQuery(string query);

        public Task<List<Person>> GetByFullname(string fullName);

        public void Create(Person person);

        public void Update(Person person);
        public void Delete(Person person);

        public bool Exist(int id);

        public Task<Person> GetPersonWithLibraryCardsAndBooks(int personId);
    }
}
