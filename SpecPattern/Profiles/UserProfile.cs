using AutoMapper;
using SpecPattern.Dtos;
using SpecPattern.Models;

namespace SpecPattern.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, GetUserDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.Surname} {src.Name}"));
    }
}