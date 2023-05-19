﻿using NG_2023_Kanban.Enums;

namespace NG_2023_Kanban.DTOs
{
    public class UserDto : BaseDto
    {
        public string FullName { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public int Role { get; set; } = (int)Roles.User;

        public virtual ICollection<BoardDto>? Boards { get; set; } = new HashSet<BoardDto>();
        public virtual ICollection<CardDto>? Cards { get; set; } = new HashSet<CardDto>();
        public virtual ICollection<CommentDto>? Comments { get; set; } = new HashSet<CommentDto>();
    }
}
