using Assignment3_WebAPI.Models.Dtos.CharacterDtos;
using Assignment3_WebAPI.Models;
using AutoMapper;
using Assignment3_WebAPI.Models.Dtos.FranchiseDtos;

namespace Assignment3_WebAPI.Profiles
{
    public class FranchiseProfile : Profile
    {
        public FranchiseProfile() 
        {
            CreateMap<AddFranchiseDto, Franchise>();
            CreateMap<PutFranchiseDto, Franchise>();
            CreateMap<Franchise, GetFranchiseDto>()
                .ForMember(dto => dto.Movies, options =>
                options.MapFrom(movieDomain => movieDomain.Movies.Select(movie => $"api/movie/{movie.Id}").ToList()));

        }
    }
}
