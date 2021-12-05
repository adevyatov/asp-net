using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Models.Context;

namespace WebApi.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly AppContext _context;

        public GenreRepository(AppContext context)
        {
            _context = context;
        }

        public Task<List<Genre>> GetAllByIds(IEnumerable<int> ids)
        {
            return _context.Genres.Where(g => ids.Contains(g.Id)).ToListAsync();
        }
    }
}
