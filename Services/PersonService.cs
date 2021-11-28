using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.Models;
using WebApi.Models.Dto;
using WebApi.Models.Dto.Request;
using WebApi.Repositories;

namespace WebApi.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ILibraryCardRepository _libraryCardRepository;
        private readonly IMapper _mapper;

        public PersonService(
            IPersonRepository personRepository,
            IBookRepository bookRepository,
            ILibraryCardRepository libraryCardRepository,
            IMapper mapper
        )
        {
            _personRepository = personRepository;
            _bookRepository = bookRepository;
            _libraryCardRepository = libraryCardRepository;
            _mapper = mapper;
        }

        public PersonDto Create(CreatePersonDto personDto)
        {
            var person = _mapper.Map<CreatePersonDto, Person>(personDto);
            _personRepository.Create(person);

            return _mapper.Map<Person, PersonDto>(person);
        }

        public PersonDto Update(UpdatePersonDto personDto)
        {
            var person = GetExistedPerson(personDto.Id);

            _mapper.Map(personDto, person);
            _personRepository.Update(person);

            return _mapper.Map<Person, PersonDto>(person);
        }

        public async Task<bool> DeleteByFullName(string fullName)
        {
            var persons = await _personRepository.GetByFullname(fullName);

            foreach (var person in persons)
            {
                _personRepository.Delete(person);
            }

            return true;
        }

        public async Task<IEnumerable<LibraryCardDto>> GetPersonBooks(int id)
        {
            CheckPersonExist(id);

            var libraryCards = await _libraryCardRepository.GetLibraryCardsByPersonId(id);

            return _mapper.Map<IEnumerable<LibraryCard>, IEnumerable<LibraryCardDto>>(libraryCards);
        }

        public async Task<PersonDto> TakeBook(TakeBookDto dto)
        {
            var person = GetExistedPerson(dto.PersonId);
            var book = await GetExistedBook(dto.BookId);
            var libraryCard = new LibraryCard()
            {
                Book = book,
                Person = person,
                Date = DateTime.Today,
            };

            _libraryCardRepository.Create(libraryCard);

            // update person information
            person = await _personRepository.GetPersonWithLibraryCardsAndBooks(dto.PersonId);

            return _mapper.Map<Person, PersonDto>(person);
        }

        public async Task<PersonDto> GiveAwayBook(GiveAwayBookDto dto)
        {
            CheckPersonExist(dto.PersonId);

            var libraryCard = await _libraryCardRepository.GetByPersonAndLibraryCardId(dto.PersonId, dto.LibraryCardId)
                ?? throw new ConstraintException("LibraryCard with given id does not exist");

            _libraryCardRepository.Delete(libraryCard);

            var person = await _personRepository.GetPersonWithLibraryCardsAndBooks(dto.PersonId);

            return _mapper.Map<Person, PersonDto>(person);
        }

        public PersonDto GetPerson(int id)
        {
            var person = GetExistedPerson(id);

            return _mapper.Map<Person, PersonDto>(person);
        }

        public async Task<IEnumerable<PersonDto>> GetPersons()
        {
            var persons = await _personRepository.GetAll();

            return _mapper.Map<IEnumerable<Person>, IEnumerable<PersonDto>>(persons);
        }

        public bool Delete(int id)
        {
            var person = GetExistedPerson(id);
            _personRepository.Delete(person);

            return true;
        }

        private Person GetExistedPerson(int id)
        {
            return _personRepository.GetById(id)
                   ?? throw new ConstraintException("Person with given id does not eixsts");
        }

        private void CheckPersonExist(int id)
        {
            if (_personRepository.Exist(id) == false)
            {
                throw new ConstraintException("Book with given id does not eixsts");
            }
        }

        private Task<Book> GetExistedBook(int id)
        {
            return (_bookRepository.GetById(id)
                    ?? throw new ConstraintException("Book with given id does not eixsts"))!;
        }

        public bool Exist(int id)
        {
            return _personRepository.Exist(id);
        }
    }
}
