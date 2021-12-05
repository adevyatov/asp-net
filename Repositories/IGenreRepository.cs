using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IGenreRepository
    {
        public Task<List<Genre>> GetAllByIds(IEnumerable<int> ids);
    }
}
