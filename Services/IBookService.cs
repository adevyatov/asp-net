using System.Collections.Generic;
using WebApi.Models.Dto;
using WebApi.ViewModels;

namespace WebApi.Services
{
    public interface IBookService
    {
        public IEnumerable<BookDto> GetBooks();
        public IEnumerable<BookDto> GetBooks(int authorId);
        public BookDto Add(AddBookViewModel model);
        public bool Delete(int id);

        public bool DeleteByAuthorId(int authorId);
    }
}
