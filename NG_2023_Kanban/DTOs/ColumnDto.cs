namespace NG_2023_Kanban.DTOs
{
    public class ColumnDto : BaseDto
    {
        public string Name { get; set; }
        public int BoardId { get; set; }

        public BoardDto Board { get; set; }

        public ICollection<CardDto> Cards { get; set; } = new List<CardDto>();
    }
}
