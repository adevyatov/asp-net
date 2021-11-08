using System.Collections.Generic;
using WebApi.Models.Dto;

namespace WebApi.Repositories
{
    public interface IBookRepository
    {
        public IEnumerable<BookDto> GetAll();

        public BookDto? GetById(int id);

        public IEnumerable<BookDto> GetByAuthorId(int authorId);

        public BookDto Add(BookDto book);

        public void Remove(BookDto book);
    }
}
