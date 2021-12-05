using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Exceptions;
using WebApi.Models;
using WebApi.Models.Dto;
using WebApi.Models.Dto.Request;
using WebApi.Repositories;
using WebApi.ViewModels;

namespace WebApi.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILibraryCardRepository _libraryCardRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _dtoMapper;

        public BookService(
            IBookRepository bookRepository,
            ILibraryCardRepository libraryCardRepository,
            IGenreRepository genreRepository,
            IMapper dtoMapper
        ) {
            _bookRepository = bookRepository;
            _libraryCardRepository = libraryCardRepository;
            _genreRepository = genreRepository;
            _dtoMapper = dtoMapper;
        }

        public Task<bool> Exist(int id)
        {
            return _bookRepository.Exist(id);
        }

        public Task<BookDto> GetBook(int bookId)
        {
            var book = GetExistedBook(bookId);

            return _dtoMapper.Map<Task<Book>, Task<BookDto>>(book);
        }

        public async Task<IEnumerable<BookDto>> GetBooks(OrderDto? orderBy)
        {
            var books = await _bookRepository.GetAll();
            var result = _dtoMapper.Map<IEnumerable<Book>, IEnumerable<BookDto>>(books);

            if (orderBy is not {OrderBy: { }})
                return result;

            // sorting
            var textInfo = new CultureInfo("en-US", false).TextInfo;
            var orderByProperty = textInfo.ToTitleCase(textInfo.ToTitleCase(orderBy.OrderBy));
            var propertyInfo = typeof(BookDto).GetProperty(orderByProperty);
            if (propertyInfo == null)
            {
                throw new ConstraintException("Invalid sorting field");
            }

            return orderBy.Direction.ToUpper() == "DESC"
                ? result.OrderByDescending(x => propertyInfo.GetValue(x, null))
                : result.OrderBy(x => propertyInfo.GetValue(x, null));
        }

        public Task<IEnumerable<BookDto>> GetBooks(int authorId)
        {
            return Task.FromResult<IEnumerable<BookDto>>(new List<BookDto>()); //_bookRepository.GetByAuthorId(authorId));
        }

        public async Task<BookDto> Add(CreateBookDto dto)
        {
            var book = _dtoMapper.Map<CreateBookDto, Book>(dto);
            await _bookRepository.Create(book);
            var bookDto = _dtoMapper.Map<Book, BookDto>(book);

            return bookDto;
        }

        public async Task<bool> Delete(int id)
        {
            var book = await _bookRepository.GetById(id);

            if (await _libraryCardRepository.HasAnyByBookId(id)) return false;

            // remove book
            _bookRepository.Delete(book);

            return true;
        }

        public async Task<bool> DeleteByAuthorId(int authorId)
        {
            var books = await _bookRepository.GetByAuthorId(authorId);

            foreach (var book in books)
            {
                _bookRepository.Delete(book);
            }

            return true;
        }

        public async Task<BookDto> UpdateGenres(UpdateBookGenreDto dto)
        {
            var book = await (_bookRepository.GetByIdWithGenres(dto.BookId))
                ?? throw new HttpNotFoundException("Book with given id not found");

            var genres = await _genreRepository.GetAllByIds(dto.GenreIds);

            await _bookRepository.UpdateGenres(book, genres);

            return _dtoMapper.Map<Book, BookDto>(book);
        }

        public async Task<List<BookDto>> GetBooksByAuthorName(AuthorNameDto dto)
        {
            var books = await _bookRepository.GetByAuthorName(dto.FirstName, dto.LastName, dto.MiddleName);

            return _dtoMapper.Map<List<Book>, List<BookDto>>(books);
        }

        public async Task<List<BookDto>> GetBooksByGenreId(int genreId)
        {
            var books = await _bookRepository.GetByGenreId(genreId);

            return _dtoMapper.Map<List<Book>, List<BookDto>>(books);
        }

        private Task<Book> GetExistedBook(int bookId)
        {
            return (_bookRepository.GetById(bookId) ?? throw new HttpNotFoundException("Book with given id not found"))!;
        }
    }
}
