using System.Collections.Generic;
using WebApi.Exceptions;
using WebApi.Models.Dto;
using WebApi.Repositories;
using WebApi.ViewModels;

namespace WebApi.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public BookDto GetBook(int bookId)
        {
            return _repository.GetById(bookId) ?? throw new HttpNotFoundException("Book not found");
        }

        public IEnumerable<BookDto> GetBooks()
        {
            return _repository.GetAll();
        }

        public IEnumerable<BookDto> GetBooks(int authorId)
        {
            return _repository.GetByAuthorId(authorId);
        }

        public BookDto Add(AddBookViewModel model)
        {
            var book = new BookDto
            {
                Title = model.Title,
                AuthorId = model.AuthorId,
                Genre = model.Genre,
            };

            _repository.Add(book);

            return book;
        }

        public bool Delete(int id)
        {
            var book = _repository.GetById(id);

            if (book == null)
            {
                return false;
            }

            // remove book
            _repository.Remove(book);

            return true;
        }

        public bool DeleteByAuthorId(int authorId)
        {
            foreach (var book in _repository.GetByAuthorId(authorId))
            {
                _repository.Remove(book);
            }

            return true;
        }
    }
}
