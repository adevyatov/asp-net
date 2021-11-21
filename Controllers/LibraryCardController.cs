using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    /// <summary>
    ///     2.1.2 - Контроллер, отвечающий за получение книги человеком
    /// </summary>
    [ApiController]
    [Route("library-card")]
    public class LibraryCardController : Controller
    {
        private readonly ILibraryCardService _cardService;

        public LibraryCardController(ILibraryCardService cardService)
        {
            _cardService = cardService;
        }

        /// <summary>
        ///     2.1.4 - Метод POST отвечающий за взятие книги читателем
        /// </summary>
        [HttpPost]
        public LibraryCard TakeBook(AddLibraryCardViewModel model)
        {
            return _cardService.TakeBook(model.HumanId, model.BookId);
        }
    }
}
