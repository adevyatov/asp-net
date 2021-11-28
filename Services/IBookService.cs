using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Models.Dto;
using WebApi.Models.Dto.Request;

namespace WebApi.Services
{
    public interface IBookService
    {
        public Task<bool> Exist(int id);
        public Task<BookDto> GetBook(int bookId);
        public Task<IEnumerable<BookDto>> GetBooks(OrderDto? orderBy);
        public Task<IEnumerable<BookDto>> GetBooks(int authorId);
        public Task<BookDto> Add(CreateBookDto book);
        public Task<bool> Delete(int id);
        public Task<bool> DeleteByAuthorId(int authorId);
        public Task<BookDto> UpdateGenres(UpdateBookGenreDto dto);

        public Task<List<BookDto>> GetBooksByAuthorName(AuthorNameDto dto);
        Task<List<BookDto>> GetBooksByGenreId(int genreId);
    }
}
