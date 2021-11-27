using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories
{
    public interface ILibraryCardRepository
    {
        public void Create(LibraryCard card);

        public void Delete(LibraryCard card);

        public Task<LibraryCard> GetByPersonAndLibraryCardId(int personId, int bookId);

        public Task<List<LibraryCard>> GetLibraryCardsByPersonId(int id);
        public Task<List<LibraryCard>> GetByPersonIdWithBooksGenresAndAuthors(int id);
    }
}
