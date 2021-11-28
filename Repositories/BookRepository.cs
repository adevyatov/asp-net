using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using AppContext = WebApi.Models.Context.AppContext;

namespace WebApi.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppContext _context;

        public BookRepository(AppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genres)
                .ToListAsync();
        }

        public Task<Book> GetById(int id)
        {
            return _context.Books.FirstOrDefaultAsync(h => h.Id == id);
        }

        public Task<Book> GetByIdWithGenres(int id)
        {
            return _context.Books.Include(b => b.Genres).FirstOrDefaultAsync(b => b.Id == id);
        }

        public Task<List<Book>> GetByAuthorId(int authorId)
        {
            return _context.Books.Where(b => b.AuthorId == authorId).ToListAsync();
        }

        public Task<Book> Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();

            return Task.FromResult(book);
        }

        public Task<Book> UpdateGenres(Book book, List<Genre> genres)
        {
            book.Genres = genres;
            _context.SaveChanges();

            return Task.FromResult(book);
        }

        public void Delete(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChangesAsync();
        }

        public Task<bool> Exist(int id)
        {
            return _context.Books.AnyAsync(e => e.Id == id);
        }

        public Task<List<Book>> GetByAuthorName(string? firstName, string? lastName, string? middleName)
        {
            var books = _context.Books
                .Include(b=>b.Author)
                .Include(b=>b.Genres)
                .AsQueryable();

            if (firstName != null)
            {
                books = books.Where(b => b.Author.FirstName == firstName);
            }

            if (lastName != null)
            {
                books = books.Where(b => b.Author.LastName == lastName);
            }

            if (middleName != null)
            {
                books = books.Where(b => b.Author.MiddleName == middleName);
            }

            return books.ToListAsync();
        }

        public Task<List<Book>> GetByGenreId(int genreId)
        {
            return _context.Books
                .Include(b => b.Genres)
                .Include(b => b.Author)
                .Where(b => b.Genres.Any(g => g.Id == genreId))
                .ToListAsync();
        }
    }
}
