using Assignment3_WebAPI.Models;
using Assignment3_WebAPI.Models.Dtos;
using AutoMapper;

namespace Assignment3_WebAPI.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile() 
        {
            CreateMap<AddMovieDto, Movie>();
            CreateMap<PutMovieDto, Movie>();
            CreateMap<Movie , GetMovieDto>()
                .ForMember(dto => dto.Characters, options =>
                options.MapFrom(movieDomain => movieDomain.Characters.Select(character => $"api/character/{character.Id}").ToList()));
        }
    }
}
