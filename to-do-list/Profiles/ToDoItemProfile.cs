using AutoMapper;
using to_do_list.Data.Entities;
using to_do_list.Models;

namespace to_do_list.Profiles
{
    public class ToDoItemProfile:Profile
    {
        public ToDoItemProfile()
        {
            CreateMap<ToDoItemDto, ToDoItem>()
                .ForMember(dest => dest.title, opt => opt.MapFrom(src => src.title))
                .ForMember(dest => dest.description, opt => opt.MapFrom(src => src.description))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
            CreateMap<EditToDoItemDto, ToDoItem>()
                .ForMember(dest => dest.title, opt => opt.MapFrom(src => src.title))
                .ForMember(dest => dest.description, opt => opt.MapFrom(src => src.description));
        }
    }
}
