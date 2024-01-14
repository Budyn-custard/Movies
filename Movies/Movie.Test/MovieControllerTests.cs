using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Moq;
using Movies.API.Controllers;
using Movies.Application.Helpers;
using Movies.Application.Services;
using Movies.Data.Entities;
using Movies.Models.Response;
using Movies.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Test
{
    
    public class MovieControllerTests
    {        
        [Fact]
        public async Task GetMethodReturns_Ok() 
        {
            //arrange
            Mock<IMovieService> movieService = new Mock<IMovieService>(MockBehavior.Strict);
            Mock<IMapper> mappingService = new Mock<IMapper>();
            movieService.Setup(p => p.GetMovies(It.IsAny<PageParams>())).ReturnsAsync(new List<Movie>());
            var controller = new MovieController(movieService.Object, mappingService.Object);
            //act
            var result = await controller.Get(new PageParams());

            //assert
            Assert.True(result is OkObjectResult);
            movieService.Verify(p => p.GetMovies(It.IsAny<PageParams>()), Times.Once);
        }

        [Fact]
        public async Task GetMethodReturns_BadRequest()
        {
            //arrange
            Mock<IMovieService> movieService = new Mock<IMovieService>(MockBehavior.Strict);
            Mock<IMapper> mappingService = new Mock<IMapper>();
            movieService.Setup(p => p.GetMovies(It.IsAny<PageParams>())).Throws(new BusinessException((int)HttpStatusCode.BadRequest, ""));
            var controller = new MovieController(movieService.Object, mappingService.Object);
            //act;

            //assert
            var result = await Assert.ThrowsAsync<BusinessException>(() => controller.Get(new PageParams() { FilterByType = "Wrong" }));
            Assert.True(result is BusinessException);
        }
    }
}
