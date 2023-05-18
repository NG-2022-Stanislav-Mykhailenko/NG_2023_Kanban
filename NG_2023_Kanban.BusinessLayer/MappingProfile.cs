using AutoMapper;
using NG_2023_Kanban.BusinessLayer.Models;
using NG_2023_Kanban.DataLayer.Entities;

namespace NG_2023_Kanban.BusinessLayer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BoardModel, Board>()
                .ReverseMap();
    
            CreateMap<CardModel, Card>()
                .ReverseMap();
            
            CreateMap<ColumnModel, Column>()
                .ReverseMap();

            CreateMap<CommentModel, Comment>()
                .ReverseMap();

            CreateMap<UserModel, User>()
                .ReverseMap();
        }
    }
}
