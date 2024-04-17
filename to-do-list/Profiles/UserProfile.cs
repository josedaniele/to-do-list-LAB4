using AutoMapper;
using to_do_list.Data.Entities;
using to_do_list.Models;

namespace to_do_list.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile() 
        {
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.email))
                .ForMember(dest => dest.address, opt => opt.MapFrom(src => src.address));
        }
    }
}
