using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Services
{
    public class LibraryCardService : ILibraryCardService
    {
        private readonly IPersonService _personService;
        private readonly IBookService _bookService;
        private readonly ILibraryCardRepository _repo;

        public LibraryCardService(IPersonService personService, IBookService bookService, ILibraryCardRepository repo)
        {
            _personService = personService;
            _bookService = bookService;
            _repo = repo;
        }

        public LibraryCard TakeBook(int humanId, int bookId)
        {
            var human = _personService.GetPerson(humanId);
            var book = _bookService.GetBook(bookId);
            var card = new LibraryCard();

            _repo.Create(card);

            return card;
        }
    }
}
