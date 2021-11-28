using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IBookRepository
    {
        public Task<IEnumerable<Book>> GetAll();

        public Task<Book> GetById(int id);

        public Task<Book> GetByIdWithGenres(int id);

        public Task<List<Book>> GetByAuthorId(int authorId);

        public Task<Book> Create(Book book);

        public Task<Book> UpdateGenres(Book book, List<Genre> genres);

        public void Delete(Book book);
        public Task<bool> Exist(int id);

        public Task<List<Book>> GetByAuthorName(string? firstName, string? lastName, string? middleName);
        public Task<List<Book>> GetByGenreId(int genreId);
    }
}
