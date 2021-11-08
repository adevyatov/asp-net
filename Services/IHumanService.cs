using System.Collections.Generic;
using WebApi.Models.Dto;
using WebApi.ViewModels;

namespace WebApi.Services
{
    public interface IHumanService
    {
        public IEnumerable<HumanDto> GetHumans();
        public IEnumerable<HumanDto> GetWriters();
        public IEnumerable<HumanDto> GetHumans(string query);
        public HumanDto Add(AddHumanViewModel model);
        public bool Delete(int id);
    }
}
