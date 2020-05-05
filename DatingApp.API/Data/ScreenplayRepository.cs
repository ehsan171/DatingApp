using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public class ScreenplayRepository : IScreenplayRepository
    {
        private readonly DataContext _context;
        public ScreenplayRepository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Screenplay> GetScreenplay(int id)
        {
            var screenplay =await _context.Screenplays.Include(p => p.Episodes).FirstOrDefaultAsync(u => u.Id == id);
            return screenplay;
        }

        public async Task<IEnumerable<Screenplay>> GetScreenplays()
        {
           var screenplays = await _context.Screenplays.Include(p => p.Episodes).ToListAsync();
            return screenplays;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}