using Movies.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
namespace Movies.Data.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _context;
        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }

        public Task<List<Movie>> GetMovies(Expression<Func<Movie, bool>> predicate, Expression<Func<Movie, bool>> sort, int skip, int take)
        {
            return _context.Movies.Where(predicate).OrderBy(sort).Skip(skip).Take(take).ToListAsync();
        }

        public Task<List<Movie>> GetMovies(Expression<Func<Movie, bool>> sort, int skip, int take)
        {
            return _context.Movies.OrderBy(sort).Skip(skip).Take(take).ToListAsync();
        }
    }
}
