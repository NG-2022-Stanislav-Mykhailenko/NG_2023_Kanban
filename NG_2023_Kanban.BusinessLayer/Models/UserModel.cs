using NG_2023_Kanban.BusinessLayer.Enums;

﻿namespace NG_2023_Kanban.BusinessLayer.Models
{
    public class UserModel : BaseModel
    {
        public string FullName { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public int Role { get; set; } = (int)Roles.User;

        public virtual ICollection<BoardModel>? Boards { get; set; } = new HashSet<BoardModel>();
        public virtual ICollection<CardModel>? Cards { get; set; } = new HashSet<CardModel>();
        public virtual ICollection<CommentModel>? Comments { get; set; } = new HashSet<CommentModel>();
    }
}
