using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Services;
using Movies.Models.Response;
using Movies.Models.ViewModels;

namespace Movies.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MovieController(IMovieService movieService, IMapper mapper)
        {
              _movieService = movieService;
            _mapper = mapper;
        }

        [HttpGet]
        [Produces(typeof(List<MovieViewModel>))]
        public async Task<IActionResult> Get([FromQuery]PageParams pageParams)
        {
            var movies = await _movieService.GetMovies(pageParams);
            return Ok(_mapper.Map<List<MovieViewModel>>(movies));
        }

        [HttpGet("{title}")]
        public async Task<IActionResult> Get(string title)
        {
            var movie = await _movieService.GetMovie(title);
            if(movie == null)
                return NotFound("Not Found.");

            return Ok(_mapper.Map<MovieViewModel>(movie));

        }
    }
}
