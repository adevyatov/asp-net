using System.Collections.Generic;
using WebApi.Models.Dto;

namespace WebApi.Repositories
{
    public interface IHumanRepository
    {
        public HumanDto? GetById(int id);

        public IEnumerable<HumanDto> GetAll();

        public IEnumerable<HumanDto> GetByQuery(string query);

        public IEnumerable<HumanDto> GetWriters();

        public HumanDto Add(HumanDto human);

        public void Remove(HumanDto human);
    }
}
