namespace NG_2023_Kanban.DTOs
{
    public class ColumnDto : BaseDto
    {
        public string Name { get; set; }
        public int BoardId { get; set; }

        public virtual BoardDto Board { get; set; }

        public virtual ICollection<CardDto>? Cards { get; set; } = new HashSet<CardDto>();
    }
}
