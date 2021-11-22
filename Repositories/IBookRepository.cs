using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IBookRepository
    {
        public Task<IEnumerable<Book>> GetAll();

        public Book? GetById(int id);

        public IEnumerable<Book> GetByAuthorId(int authorId);

        public Book Add(Book book);

        public void Remove(Book book);
    }
}
