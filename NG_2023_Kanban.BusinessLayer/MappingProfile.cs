using AutoMapper;
using NG_2023_Kanban.BusinessLayer.Models;
using NG_2023_Kanban.DataLayer.Entities;

namespace NG_2023_Kanban
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BoardModel, Board>()
                .ForMember(boardModel => boardModel.Id,
                opt => opt.MapFrom(board => board.Id))
                .ForMember(boardModel => boardModel.Name,
                opt => opt.MapFrom(board => board.Name))
                .ForMember(boardModel => boardModel.Users,
                opt => opt.MapFrom(board => board.Users))
                .ForMember(boardModel => boardModel.Columns,
                opt => opt.MapFrom(board => board.Columns))
                .ReverseMap();
    
            CreateMap<CardModel, Card>()
                .ForMember(cardModel => cardModel.Id,
                opt => opt.MapFrom(card => card.Id))
                .ForMember(cardModel => cardModel.Name,
                opt => opt.MapFrom(card => card.Name))
                .ForMember(cardModel => cardModel.Description,
                opt => opt.MapFrom(card => card.Description))
                .ForMember(cardModel => cardModel.AssignedId,
                opt => opt.MapFrom(card => card.AssignedId))
                .ForMember(cardModel => cardModel.ColumnId,
                opt => opt.MapFrom(card => card.ColumnId))
                .ForMember(cardModel => cardModel.SenderId,
                opt => opt.MapFrom(card => card.SenderId))
                .ForMember(cardModel => cardModel.Assigned,
                opt => opt.MapFrom(card => card.Assigned))
                .ForMember(cardModel => cardModel.Column,
                opt => opt.MapFrom(card => card.Column))
                .ForMember(cardModel => cardModel.Sender,
                opt => opt.MapFrom(card => card.Sender))
                .ForMember(cardModel => cardModel.Comments,
                opt => opt.MapFrom(card => card.Comments))
                .ReverseMap();
            
            CreateMap<ColumnModel, Column>()
                .ForMember(columnModel => columnModel.Id,
                opt => opt.MapFrom(column => column.Id))
                .ForMember(columnModel => columnModel.Name,
                opt => opt.MapFrom(column => column.Name))
                .ForMember(columnModel => columnModel.BoardId,
                opt => opt.MapFrom(column => column.BoardId))
                .ForMember(columnModel => columnModel.Board,
                opt => opt.MapFrom(column => column.Board))
                .ForMember(columnModel => columnModel.Cards,
                opt => opt.MapFrom(column => column.Cards))
                .ReverseMap();

            CreateMap<CommentModel, Comment>()
                .ForMember(commentModel => commentModel.Id,
                opt => opt.MapFrom(comment => comment.Id))
                .ForMember(commentModel => commentModel.Text,
                opt => opt.MapFrom(comment => comment.Text))
                .ForMember(commentModel => commentModel.SenderId,
                opt => opt.MapFrom(comment => comment.SenderId))
                .ForMember(commentModel => commentModel.CardId,
                opt => opt.MapFrom(comment => comment.CardId))
                .ForMember(commentModel => commentModel.Sender,
                opt => opt.MapFrom(comment => comment.Sender))
                .ForMember(commentModel => commentModel.Card,
                opt => opt.MapFrom(comment => comment.Card))
                .ReverseMap();

            CreateMap<RoleModel, Role>()
                .ForMember(roleModel => roleModel.Id,
                opt => opt.MapFrom(role => role.Id))
                .ForMember(roleModel => roleModel.Name,
                opt => opt.MapFrom(role => role.Name))
                .ForMember(roleModel => roleModel.Members,
                opt => opt.MapFrom(role => role.Members))
                .ReverseMap();

            CreateMap<UserModel, User>()
                .ForMember(userModel => userModel.Id,
                opt => opt.MapFrom(user => user.Id))
                .ForMember(userModel => userModel.FullName,
                opt => opt.MapFrom(user => user.FullName))
                .ForMember(userModel => userModel.Username,
                opt => opt.MapFrom(user => user.Username))
                .ForMember(userModel => userModel.Password,
                opt => opt.MapFrom(user => user.Password))
                .ForMember(userModel => userModel.Boards,
                opt => opt.MapFrom(user => user.Boards))
                .ForMember(userModel => userModel.CardsAssigned,
                opt => opt.MapFrom(user => user.CardsAssigned))
                .ForMember(userModel => userModel.CardsSent,
                opt => opt.MapFrom(user => user.CardsSent))
                .ForMember(userModel => userModel.Comments,
                opt => opt.MapFrom(user => user.Comments))
                .ForMember(userModel => userModel.Roles,
                opt => opt.MapFrom(user => user.Roles))
                .ReverseMap();
        }
    }
}
