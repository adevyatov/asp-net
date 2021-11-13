using WebApi.Models;

namespace WebApi.Services
{
    public interface ILibraryCardService
    {
        public LibraryCard TakeBook(int humanId, int bookId);
    }
}
