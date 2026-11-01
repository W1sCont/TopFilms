using BLL.DTO;
using DAL.Repository;
using DAL.EF;
using AutoMapper;

namespace BLL.Services
{
    public class MovieServices(IRepository db, IMapper mapper) : IMovieServices
    {

        public async Task AddMovieAsync(MovieDTO movie)
        {
            var movieEntity = mapper.Map<Movie>(movie);
            await db.AddMovie(movieEntity);
        }

        public async Task EditMovieAsync(MovieDTO movie)
        {
            var movieEntity = mapper.Map<Movie>(movie);
            await db.EditMovie(movieEntity);
        }

        public async Task DeleteMovieAsync(int id)
        {
            await db.DeleteMovie(id);
        }

        public async Task SaveAsync()
        {
            await db.Save();
        }

        public async Task<MovieDTO?> GetMovieByIdAsync(int id)
        {
            var movieEntity = await db.GetMovieById(id);
            return mapper.Map<MovieDTO>(movieEntity);
        }

        public async Task<ICollection<MovieDTO>> GetAllMoviesAsync()
        {
            var movieEntities = await db.GetAllMovies();
            return movieEntities.Select(mapper.Map<MovieDTO>).ToList();
        }
    }
}