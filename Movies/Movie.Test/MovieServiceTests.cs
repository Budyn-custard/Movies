using Moq;
using Movies.Application.Services;
using Movies.Data.Entities;
using Movies.Data.Repository;
using Movies.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Test
{
    public class MovieServiceTests
    {

        [Fact]
        public async Task GetMovies_Returns_List()
        {
            //arrange
            Mock<IMovieRepository> repository = new Mock<IMovieRepository>();
            repository.Setup(p => p.GetMovies(It.IsAny<Expression<Func<Movie, bool>>>(), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(new List<Movie>());
            var service = new MovieService(repository.Object);
            //act
            var result = await service.GetMovies(new PageParams());
            //assert
            Assert.True(result is  List<Movie>);
        }
    }
}
