using Moq;
using Movies.Application.Services;
using Movies.Data.Entities;
using Movies.Data.Repository;
using Movies.Models.Response;
using System.Linq.Expressions;

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

        [Fact]
        public async Task GetMovie_Returns_Movie()
        {
            //arrange
            Mock<IMovieRepository> repository = new Mock<IMovieRepository>();
            repository.Setup(p => p.GetMovie(It.IsAny<string>())).ReturnsAsync(new Movie());
            var service = new MovieService(repository.Object);
            //act
            var result = await service.GetMovie(string.Empty);
            //assert
            Assert.True(result is Movie);
        }
    }
}
