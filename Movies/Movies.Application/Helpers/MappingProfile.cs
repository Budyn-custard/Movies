using AutoMapper;
using Movies.Data.Entities;
using Movies.Models.ViewModels;

namespace Movies.Application.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie,MovieViewModel>().ReverseMap();         
        }
    }
}
