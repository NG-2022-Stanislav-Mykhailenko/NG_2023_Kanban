namespace NG_2023_Kanban.DTOs
{
    public class UserDto : BaseDto
    {
        public string FullName { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<BoardDto> Boards { get; set; } = new List<BoardDto>();
        public ICollection<CardDto> CardsAssigned { get; set; } = new List<CardDto>();
        public ICollection<CardDto> CardsSent { get; set; } = new List<CardDto>();
        public ICollection<CommentDto> Comments { get; set; } = new List<CommentDto>();
        public ICollection<RoleDto> Roles { get; set; } = new List<RoleDto>();
    }
}
