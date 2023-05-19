using NG_2023_Kanban.DataLayer.Enums;

﻿namespace NG_2023_Kanban.DataLayer.Entities
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public int Role { get; set; } = (int)Roles.User;

        public virtual ICollection<Board>? Boards { get; set; } = new HashSet<Board>();
        public virtual ICollection<Card>? Cards { get; set; } = new HashSet<Card>();
        public virtual ICollection<Comment>? Comments { get; set; } = new HashSet<Comment>();
    }
}
