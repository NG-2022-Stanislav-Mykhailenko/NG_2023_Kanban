namespace NG_2023_Kanban.DTOs
{
    public class CardDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int SenderId { get; set; }
        public int ColumnId { get; set; }

        public virtual UserDto Sender { get; set; }
        public virtual ColumnDto Column { get; set; }

        public virtual ICollection<CommentDto> Comments { get; set; } = new HashSet<CommentDto>();
    }
}
