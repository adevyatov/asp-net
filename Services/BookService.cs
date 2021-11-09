using System.Collections.Generic;
using WebApi.Exceptions;
using WebApi.Models.Dto;
using WebApi.Repositories;
using WebApi.ViewModels;

namespace WebApi.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IHumanRepository _humanRepository;

        public BookService(IBookRepository bookRepository, IHumanRepository humanRepository)
        {
            _bookRepository = bookRepository;
            _humanRepository = humanRepository;
        }

        public BookDto GetBook(int bookId)
        {
            return _bookRepository.GetById(bookId) ?? throw new HttpNotFoundException("Book not found");
        }

        public IEnumerable<BookDto> GetBooks()
        {
            return _bookRepository.GetAll();
        }

        public IEnumerable<BookDto> GetBooks(int authorId)
        {
            return _bookRepository.GetByAuthorId(authorId);
        }

        public BookDto Add(AddBookViewModel model)
        {
            var human = _humanRepository.GetById(model.AuthorId) ?? throw new HttpNotFoundException("Author not found");

            var book = new BookDto
            {
                Title = model.Title,
                AuthorId = human.Id,
                Genre = model.Genre,
            };

            _bookRepository.Add(book);

            return book;
        }

        public bool Delete(int id)
        {
            var book = _bookRepository.GetById(id);

            if (book == null)
            {
                return false;
            }

            // remove book
            _bookRepository.Remove(book);

            return true;
        }

        public bool DeleteByAuthorId(int authorId)
        {
            foreach (var book in _bookRepository.GetByAuthorId(authorId))
            {
                _bookRepository.Remove(book);
            }

            return true;
        }
    }
}
