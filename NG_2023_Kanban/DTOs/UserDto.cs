namespace NG_2023_Kanban.DTOs
{
    public class UserDto : BaseDto
    {
        public string FullName { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<BoardDto>? Boards { get; set; } = new HashSet<BoardDto>();
        public virtual ICollection<CardDto>? CardsAssigned { get; set; } = new HashSet<CardDto>();
        public virtual ICollection<CardDto>? CardsSent { get; set; } = new HashSet<CardDto>();
        public virtual ICollection<CommentDto>? Comments { get; set; } = new HashSet<CommentDto>();
        public virtual ICollection<RoleDto>? Roles { get; set; } = new HashSet<RoleDto>();
    }
}
