using System.Collections.Generic;
using WebApi.Models.Dto;
using WebApi.Repositories;
using WebApi.ViewModels;

namespace WebApi.Services
{
    public class HumanService : IHumanService
    {
        private readonly IHumanRepository _humanRepository;
        private readonly IBookRepository _bookRepository;

        public HumanService(IHumanRepository humanRepository, IBookRepository bookRepository)
        {
            _humanRepository = humanRepository;
            _bookRepository = bookRepository;
        }

        public IEnumerable<HumanDto> GetHumans()
        {
            return _humanRepository.GetAll();
        }

        public IEnumerable<HumanDto> GetWriters()
        {
            return _humanRepository.GetWriters();
        }

        public IEnumerable<HumanDto> GetHumans(string query)
        {
            return _humanRepository.GetByQuery(query.Trim());
        }

        public HumanDto Add(AddHumanViewModel model)
        {
            var human = new HumanDto
            {
                Name = model.Name,
                Surname = model.Surname,
                Patronymic = model.Patronymic,
                Birthday = model.Birthday,
            };

            return _humanRepository.Add(human);
        }

        public bool Delete(int id)
        {
            var human = _humanRepository.GetById(id);

            if (human == null) return false;

            // remove human
            _humanRepository.Remove(human);

            // remove human's books
            foreach (var book in _bookRepository.GetByAuthorId(human.Id))
            {
                _bookRepository.Remove(book);
            }

            return true;
        }
    }
}
