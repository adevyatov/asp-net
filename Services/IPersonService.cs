using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Models.Dto;
using WebApi.Models.Dto.Request;
using WebApi.ViewModels;

namespace WebApi.Services
{
    public interface IPersonService
    {
        public PersonDto Create(CreatePersonDto person);


        public PersonDto Update(UpdatePersonDto personDto);

        public bool Delete(int id);

        public Task<bool> DeleteByFullName(string fullName);

        public Task<IEnumerable<LibraryCardDto>> GetPersonBooks(int id);

        public Task<PersonDto> TakeBook(TakeBookDto dto);

        public Task<PersonDto> GiveAwayBook(GiveAwayBookDto dto);

        public bool Exist(int id);
        public PersonDto GetPerson(int id);
        public Task<IEnumerable<PersonDto>> GetPersons();
    }
}
