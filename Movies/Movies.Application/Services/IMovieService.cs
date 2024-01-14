using Movies.Data.Entities;
using Movies.Models.Response;

namespace Movies.Application.Services
{
    public interface IMovieService
    {
        Task<List<Movie>> GetMovies(PageParams pageParams);
        Task<Movie> GetMovie(string title);
    }
}
