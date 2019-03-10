using AspNetMvcCoreExamples.Entities.Models;
using AspNetMvcCoreExamples.Entities.ViewModels;
using AutoMapper;

namespace AspNetMvcCoreExamples.Business.AutoMapperProfiles
{
    public class MyProfile : Profile
    {
        public MyProfile()
        {
            // Movies
            this.CreateMap<Movie, MovieViewModel>()
                .ReverseMap();
        }
    }
}
