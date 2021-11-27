using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using AppContext = WebApi.Models.Context.AppContext;

namespace WebApi.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppContext _context;

        public PersonRepository(AppContext context)
        {
            _context = context;
        }

        public Person? GetById(int id)
        {
            return _context.Persons.FirstOrDefault(h => h.Id == id);
        }

        public Task<List<Person>> GetAll()
        {
            return _context.Persons.ToListAsync();
        }

        public Task<List<Person>> GetByQuery(string query)
        {
            return _context.Persons.Where(h =>
                h.Name.Contains(query) ||
                h.Surname.Contains(query) ||
                (h.Patronymic ?? "").Contains(query)
            ).ToListAsync();
        }

        public async Task<List<Person>> GetByFullname(string fullName)
        {
            var parts = fullName.Split(" ");
            var surName = parts.ElementAtOrDefault(0);
            var name = parts.ElementAtOrDefault(1);
            var patronymic = parts.ElementAtOrDefault(2);

            return await _context.Persons.Where(p =>
                p.Surname == surName &&
                p.Name == name &&
                p.Patronymic == patronymic
            ).ToListAsync();
        }

        public void Create(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
        }

        public void Update(Person person)
        {
            _context.SaveChanges();
        }

        public void Delete(Person person)
        {
            _context.Persons.Remove(person);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.Persons.Any(e => e.Id == id);
        }

        public Task<Person> GetPersonWithLibraryCardsAndBooks(int personId)
        {
            return _context.Persons
                .Include(p => p.LibraryCards)
                .ThenInclude(lc => lc.Book)
                .FirstOrDefaultAsync(p => p.Id == personId);
        }
    }
}
