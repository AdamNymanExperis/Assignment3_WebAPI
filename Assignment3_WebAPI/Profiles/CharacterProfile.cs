using Assignment3_WebAPI.Models;
using Microsoft.Extensions.Options;
using AutoMapper;
using Assignment3_WebAPI.Models.Dtos.MovieDtos;
using Assignment3_WebAPI.Models.Dtos;
using Assignment3_WebAPI.Models.Dtos.CharacterDtos;

namespace Assignment3_WebAPI.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile() 
        {
            CreateMap<AddCharacterDto, Character>();
            CreateMap<PutCharacterDto, Character>();
            CreateMap<Character, GetCharacterDto>()
                .ForMember(dto => dto.Movies, options =>
                options.MapFrom(movieDomain => movieDomain.Movies.Select(movie => $"api/movie/{movie.Id}").ToList()));
        }
    }
}
