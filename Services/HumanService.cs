using System.Collections.Generic;
using WebApi.Exceptions;
using WebApi.Models.Dto;
using WebApi.Repositories;
using WebApi.ViewModels;

namespace WebApi.Services
{
    public class HumanService : IHumanService
    {
        private readonly IHumanRepository _humanRepository;
        private readonly IBookService _bookService;

        public HumanService(IHumanRepository humanRepository, IBookService bookService)
        {
            _humanRepository = humanRepository;
            _bookService = bookService;
        }

        public HumanDto GetHuman(int id)
        {
            return _humanRepository.GetById(id) ?? throw new HttpNotFoundException("Human not found");
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
            var human = GetHuman(id);

            if (human == null) return false;

            // remove human
            _humanRepository.Remove(human);

            // remove human's books
            _bookService.DeleteByAuthorId(human.Id);

            return true;
        }
    }
}
