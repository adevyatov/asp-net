using AutoMapper;
using WebApi.Models;
using WebApi.Models.Dto;
using WebApi.Models.Dto.Request;

namespace WebApi.Behaviour.MappingProfiles
{
    public class DefaultMappingProfile: Profile
    {
        public DefaultMappingProfile()
        {
            CreateMap<Genre, GenreDto>();
            CreateMap<Book, BookDto>();

            CreateMap<Person, PersonDto>();
            CreateMap<CreatePersonDto, Person>();

            CreateMap<Author, AuthorDto>();
            CreateMap<LibraryCard, LibraryCardDto>();
        }
    }
}
