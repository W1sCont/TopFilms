using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public interface IRepository
    {
        Task AddMovie(Movie movie);
        Task EditMovie(Movie movie);
        Task DeleteMovie(int id);
        Task Save();
        Task<Movie?> GetMovieById(int id);
        Task<ICollection<Movie>> GetAllMovies();
    }
}
