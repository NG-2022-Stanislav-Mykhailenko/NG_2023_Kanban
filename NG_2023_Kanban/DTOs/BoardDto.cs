namespace NG_2023_Kanban.DTOs
{
    public class BoardDto : BaseDto
    {
        public string Name { get; set; }

        public ICollection<UserDto> Users { get; set; } = new List<UserDto>();

        public ICollection<ColumnDto> Columns { get; set; } = new List<ColumnDto>(); 
    }
}
