using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WebApi.Models;
using WebApi.Models.Context;
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

        /// <summary>
        ///     1.2.2.3 - Статичный список людей
        /// </summary>
        private static List<Book> Books { get; } = new()
        {
        };

        private static int LastId { get; set; } = Books.Count;

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genres)
                .ToListAsync();
        }

        public Book? GetById(int id)
        {
            return Books.FirstOrDefault(h => h.Id == id);
        }

        public IEnumerable<Book> GetByAuthorId(int authorId)
        {
            throw new Exception("Not implemented");
            // return Books.Where(b => b.AuthorId == authorId).ToArray();
        }

        public Book Add(Book book)
        {
            book.Id = ++LastId;
            Books.Add(book);

            return book;
        }

        public void Remove(Book book)
        {
            Books.Remove(book);
        }
    }
}
