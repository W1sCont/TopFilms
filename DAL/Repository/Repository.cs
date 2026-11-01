using DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class Repository : IRepository
    {
        protected readonly MovieContext _context;

        public Repository(MovieContext context)
        {
            _context = context;
        }
        public async Task AddMovie(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
        }
        public async Task EditMovie(Movie movie)
        {
            _context.Movies.Update(movie);
        }
        public async Task DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Movie?> GetMovieById(int id)
        {
            return await _context.Movies.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task<ICollection<Movie>> GetAllMovies()
        {
            return await _context.Movies.AsNoTracking().OrderByDescending(m => m.Id).ToListAsync();
        }
    }
}
