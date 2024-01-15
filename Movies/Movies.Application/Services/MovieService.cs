using Movies.Application.Helpers;
using Movies.Data.Entities;
using Movies.Data.Repository;
using Movies.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;

        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }

        public Task<Movie> GetMovie(string title)
        {
            return _repository.GetMovie(title);
        }

        public Task<List<Movie>> GetMovies(PageParams pageParams)
        {
            if (!PredicateHelper.IsValidColumn(pageParams.OrderBy))
                throw new BusinessException((int)HttpStatusCode.BadRequest, "Order by is not valid.");

            var orderbByPredicate = PredicateHelper.BuildPredicate(pageParams.OrderBy, "Desc");
            if (!string.IsNullOrEmpty(pageParams.FilterByType) || !string.IsNullOrEmpty(pageParams.Filter))
            {
                if (!PredicateHelper.IsValidColumn(pageParams.FilterByType))
                    throw new BusinessException((int)HttpStatusCode.BadRequest, "Filer is not valid.");
                var filterPredicate = PredicateHelper.BuildPredicate(pageParams.FilterByType, pageParams.Filter);
                return _repository.GetMovies(filterPredicate, orderbByPredicate, pageParams.Skip, pageParams.Take);
            }
            return _repository.GetMovies(orderbByPredicate, pageParams.Skip, pageParams.Take);
        }
    }
}
