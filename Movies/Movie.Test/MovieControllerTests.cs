using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Movies.API.Controllers;
using Movies.Application.Helpers;
using Movies.Application.Services;
using Movies.Data.Entities;
using Movies.Models.Response;
using System.Net;

namespace Movies.Test
{

    public class MovieControllerTests
    {        
        [Fact]
        public async Task GetManyReturns_Ok() 
        {
            //arrange
            Mock<IMovieService> movieService = new Mock<IMovieService>(MockBehavior.Strict);
            Mock<IMapper> mappingService = new Mock<IMapper>();
            movieService.Setup(p => p.GetMovies(It.IsAny<PageParams>())).ReturnsAsync(new List<Movie>());
            var controller = new MoviesController(movieService.Object, mappingService.Object);
            //act
            var result = await controller.Get(new PageParams());

            //assert
            Assert.True(result is OkObjectResult);
            movieService.Verify(p => p.GetMovies(It.IsAny<PageParams>()), Times.Once);
        }

        [Fact]
        public async Task GetManyReturns_BadRequest()
        {
            //arrange
            Mock<IMovieService> movieService = new Mock<IMovieService>(MockBehavior.Strict);
            Mock<IMapper> mappingService = new Mock<IMapper>();
            movieService.Setup(p => p.GetMovies(It.IsAny<PageParams>())).Throws(new BusinessException((int)HttpStatusCode.BadRequest, ""));
            var controller = new MoviesController(movieService.Object, mappingService.Object);
            //act;

            //assert
            var result = await Assert.ThrowsAsync<BusinessException>(() => controller.Get(new PageParams() { FilterByType = "Wrong" }));
            Assert.True(result is BusinessException);
        }

        [Fact]
        public async Task GetReturns_Ok()
        {
            //arrange
            Mock<IMovieService> movieService = new Mock<IMovieService>(MockBehavior.Strict);
            Mock<IMapper> mappingService = new Mock<IMapper>();
            movieService.Setup(p => p.GetMovie(It.IsAny<string>())).ReturnsAsync(new Movie());
            var controller = new MoviesController(movieService.Object, mappingService.Object);
            //act;

            //assert
            var result = await controller.Get(string.Empty);
            Assert.True(result is OkObjectResult);
        }

        [Fact]
        public async Task GetReturns_NotFound()
        {
            //arrange
            Mock<IMovieService> movieService = new Mock<IMovieService>(MockBehavior.Strict);
            Mock<IMapper> mappingService = new Mock<IMapper>();
            movieService.Setup(p => p.GetMovie(It.IsAny<string>())).ReturnsAsync((Movie)null);
            var controller = new MoviesController(movieService.Object, mappingService.Object);
            //act;

            //assert
            var result = await controller.Get(string.Empty);
            Assert.True(result is NotFoundObjectResult);
        }
    }
}
