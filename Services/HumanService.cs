using System;
using System.Collections.Generic;
using WebApi.Models.Dto;
using WebApi.Repositories;
using WebApi.ViewModels;

namespace DefaultNamespace
{
    public class HumanService
    {
        private readonly IHumanRepository _humanRepo;
        private readonly IBookRepository _bookRepo;

        public HumanService(IHumanRepository humanRepo, IBookRepository bookRepo)
        {
            _humanRepo = humanRepo;
            _bookRepo = bookRepo;
        }

        public IEnumerable<HumanDto> GetHumans()
        {
            return _humanRepo.GetAll();
        }

        public IEnumerable<HumanDto> GetWriters()
        {
            return _humanRepo.GetWriters();
        }

        public IEnumerable<HumanDto> GetHumans(string query)
        {
            return _humanRepo.GetByQuery(query.Trim());
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

            return _humanRepo.Add(human);
        }

        public bool Delete(int id)
        {
            var human = _humanRepo.GetById(id);

            if (human == null) return false;

            // remove human
            _humanRepo.Remove(human);

            // remove human's books
            foreach (var book in _bookRepo.GetByAuthorId(human.Id))
            {
                _bookRepo.Remove(book);
            }

            return true;
        }
    }
}
