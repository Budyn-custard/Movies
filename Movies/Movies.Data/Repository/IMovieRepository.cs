using Movies.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Repository
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetMovies(Expression<Func<Movie, bool>> predicate, Expression<Func<Movie, bool>> sort, int skip, int take);
        Task<List<Movie>> GetMovies(Expression<Func<Movie, bool>> sort, int skip, int take);
    }
}
