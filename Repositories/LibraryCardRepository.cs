using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Models.Context;

namespace WebApi.Repositories
{
    public class LibraryCardRepository : ILibraryCardRepository
    {
        private readonly AppContext _context;

        public LibraryCardRepository(AppContext context)
        {
            _context = context;
        }

        public void Create(LibraryCard card)
        {
            _context.LibraryCards.Add(card);
            _context.SaveChanges();
        }

        public void Delete(LibraryCard card)
        {
            _context.LibraryCards.Remove(card);
            _context.SaveChanges();
        }

        public Task<LibraryCard> GetByPersonAndLibraryCardId(int personId, int libraryCardId)
        {
            return _context.LibraryCards
                .Where(lc => lc.PersonId == personId && lc.Id == libraryCardId)
                .FirstOrDefaultAsync();
        }

        public Task<List<LibraryCard>> GetLibraryCardsByPersonId(int id)
        {
            return _context.LibraryCards
                .Include(lc => lc.Book)
                .ThenInclude(b => b.Author)
                .Include(lc => lc.Book)
                .ThenInclude(b => b.Genres)
                .Where(lc => lc.PersonId == id).ToListAsync();
        }

        public Task<List<LibraryCard>> GetByPersonIdWithBooksGenresAndAuthors(int id)
        {
            return _context.LibraryCards
                .Include(lc => lc.Book)
                .ThenInclude(b => b.Author)
                .Include(lc => lc.Book)
                .ThenInclude(b => b.Genres)
                .Where(lc => lc.PersonId == id).ToListAsync();
        }
    }
}
