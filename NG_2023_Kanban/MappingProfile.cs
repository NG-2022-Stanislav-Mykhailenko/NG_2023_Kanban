using AutoMapper;
using NG_2023_Kanban.DTOs;
using NG_2023_Kanban.BusinessLayer.Models;

namespace NG_2023_Kanban
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BoardDto, BoardModel>()
                .ReverseMap();
    
            CreateMap<CardDto, CardModel>()
                .ReverseMap();
            
            CreateMap<ColumnDto, ColumnModel>()
                .ReverseMap();

            CreateMap<CommentDto, CommentModel>()
                .ReverseMap();

            CreateMap<RoleDto, RoleModel>()
                .ReverseMap();

            CreateMap<UserDto, UserModel>()
                .ReverseMap();
        }
    }
}
