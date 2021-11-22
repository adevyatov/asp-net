using AutoMapper;
using WebApi.Models;
using WebApi.Models.Dto;

namespace WebApi.Services.MappingProfiles
{
    public class DefaultMappingProfile: Profile
    {
        public DefaultMappingProfile()
        {
            CreateMap<Genre, GenreDto>();

            CreateMap<Book, BookDto>();

            CreateMap<Person, PersonDto>().ReverseMap();
        }
    }
}
