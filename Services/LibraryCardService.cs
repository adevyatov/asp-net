using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Services
{
    public class LibraryCardService : ILibraryCardService
    {
        private readonly IHumanService _humanService;
        private readonly IBookService _bookService;
        private readonly ILibraryCardRepository _repo;

        public LibraryCardService(IHumanService humanService, IBookService bookService, ILibraryCardRepository repo)
        {
            _humanService = humanService;
            _bookService = bookService;
            _repo = repo;
        }

        public LibraryCard TakeBook(int humanId, int bookId)
        {
            var human = _humanService.GetHuman(humanId);
            var book = _bookService.GetBook(bookId);
            var card = new LibraryCard(human, book);

            _repo.Add(card);

            return card;
        }
    }
}
