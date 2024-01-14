using Movies.Data.Entities;
using Movies.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Services
{
    public interface IMovieService
    {
        Task<List<Movie>> GetMovies(PageParams pageParams);
    }
}
