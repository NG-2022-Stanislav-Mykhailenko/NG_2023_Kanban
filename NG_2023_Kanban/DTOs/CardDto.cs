namespace NG_2023_Kanban.DTOs
{
    public class CardDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AssignedId { get; set; }
        public int ColumnId { get; set; }
        public int SenderId { get; set; }

        public UserDto Assigned { get; set; }
        public ColumnDto Column { get; set; }
        public UserDto Sender { get; set; }

        public ICollection<CommentDto> Comments { get; set; } = new List<CommentDto>();
    }
}
