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
                .ForMember(boardDto => boardDto.Id,
                opt => opt.MapFrom(boardModel => boardModel.Id))
                .ForMember(boardDto => boardDto.Name,
                opt => opt.MapFrom(boardModel => boardModel.Name))
                .ForMember(boardDto => boardDto.Users,
                opt => opt.MapFrom(boardModel => boardModel.Users))
                .ForMember(boardDto => boardDto.Columns,
                opt => opt.MapFrom(boardModel => boardModel.Columns))
                .ReverseMap();
    
            CreateMap<CardDto, CardModel>()
                .ForMember(cardDto => cardDto.Id,
                opt => opt.MapFrom(cardModel => cardModel.Id))
                .ForMember(cardDto => cardDto.Name,
                opt => opt.MapFrom(cardModel => cardModel.Name))
                .ForMember(cardDto => cardDto.Description,
                opt => opt.MapFrom(cardModel => cardModel.Description))
                .ForMember(cardDto => cardDto.AssignedId,
                opt => opt.MapFrom(cardModel => cardModel.AssignedId))
                .ForMember(cardDto => cardDto.ColumnId,
                opt => opt.MapFrom(cardModel => cardModel.ColumnId))
                .ForMember(cardDto => cardDto.SenderId,
                opt => opt.MapFrom(cardModel => cardModel.SenderId))
                .ForMember(cardDto => cardDto.Assigned,
                opt => opt.MapFrom(cardModel => cardModel.Assigned))
                .ForMember(cardDto => cardDto.Column,
                opt => opt.MapFrom(cardModel => cardModel.Column))
                .ForMember(cardDto => cardDto.Sender,
                opt => opt.MapFrom(cardModel => cardModel.Sender))
                .ForMember(cardDto => cardDto.Comments,
                opt => opt.MapFrom(cardModel => cardModel.Comments))
                .ReverseMap();
            
            CreateMap<ColumnDto, ColumnModel>()
                .ForMember(columnDto => columnDto.Id,
                opt => opt.MapFrom(columnModel => columnModel.Id))
                .ForMember(columnDto => columnDto.Name,
                opt => opt.MapFrom(columnModel => columnModel.Name))
                .ForMember(columnDto => columnDto.BoardId,
                opt => opt.MapFrom(columnModel => columnModel.BoardId))
                .ForMember(columnDto => columnDto.Board,
                opt => opt.MapFrom(columnModel => columnModel.Board))
                .ForMember(columnDto => columnDto.Cards,
                opt => opt.MapFrom(columnModel => columnModel.Cards))
                .ReverseMap();

            CreateMap<CommentDto, CommentModel>()
                .ForMember(commentDto => commentDto.Id,
                opt => opt.MapFrom(commentModel => commentModel.Id))
                .ForMember(commentDto => commentDto.Text,
                opt => opt.MapFrom(commentModel => commentModel.Text))
                .ForMember(commentDto => commentDto.SenderId,
                opt => opt.MapFrom(commentModel => commentModel.SenderId))
                .ForMember(commentDto => commentDto.CardId,
                opt => opt.MapFrom(commentModel => commentModel.CardId))
                .ForMember(commentDto => commentDto.Sender,
                opt => opt.MapFrom(commentModel => commentModel.Sender))
                .ForMember(commentDto => commentDto.Card,
                opt => opt.MapFrom(commentModel => commentModel.Card))
                .ReverseMap();

            CreateMap<RoleDto, RoleModel>()
                .ForMember(roleDto => roleDto.Id,
                opt => opt.MapFrom(roleModel => roleModel.Id))
                .ForMember(roleDto => roleDto.Name,
                opt => opt.MapFrom(roleModel => roleModel.Name))
                .ForMember(roleDto => roleDto.Members,
                opt => opt.MapFrom(roleModel => roleModel.Members))
                .ReverseMap();

            CreateMap<UserDto, UserModel>()
                .ForMember(userDto => userDto.Id,
                opt => opt.MapFrom(userModel => userModel.Id))
                .ForMember(userDto => userDto.FullName,
                opt => opt.MapFrom(userModel => userModel.FullName))
                .ForMember(userDto => userDto.Username,
                opt => opt.MapFrom(userModel => userModel.Username))
                .ForMember(userDto => userDto.Password,
                opt => opt.MapFrom(userModel => userModel.Password))
                .ForMember(userDto => userDto.Boards,
                opt => opt.MapFrom(userModel => userModel.Boards))
                .ForMember(userDto => userDto.CardsAssigned,
                opt => opt.MapFrom(userModel => userModel.CardsAssigned))
                .ForMember(userDto => userDto.CardsSent,
                opt => opt.MapFrom(userModel => userModel.CardsSent))
                .ForMember(userDto => userDto.Comments,
                opt => opt.MapFrom(userModel => userModel.Comments))
                .ForMember(userDto => userDto.Roles,
                opt => opt.MapFrom(userModel => userModel.Roles))
                .ReverseMap();
        }
    }
}
