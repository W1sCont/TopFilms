using BLL.DTO;

namespace BLL.Services
{
    public interface IMovieServices
    {
        Task AddMovieAsync(MovieDTO movie);
        Task EditMovieAsync(MovieDTO movie);
        Task DeleteMovieAsync(int id);
        Task SaveAsync();
        Task<MovieDTO?> GetMovieByIdAsync(int id);
        Task<ICollection<MovieDTO>> GetAllMoviesAsync();
    }
}
