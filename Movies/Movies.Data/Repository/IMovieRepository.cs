using Movies.Data.Entities;
using System.Linq.Expressions;

namespace Movies.Data.Repository
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetMovies(Expression<Func<Movie, bool>> predicate, Expression<Func<Movie, bool>> sort, int skip, int take);
        Task<List<Movie>> GetMovies(Expression<Func<Movie, bool>> sort, int skip, int take);
        Task<Movie> GetMovie(string title);
    }
}
