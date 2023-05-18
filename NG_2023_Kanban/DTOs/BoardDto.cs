namespace NG_2023_Kanban.DTOs
{
    public class BoardDto : BaseDto
    {
        public string Name { get; set; }

        public virtual ICollection<UserDto>? Users { get; set; } = new HashSet<UserDto>();

        public virtual ICollection<ColumnDto>? Columns { get; set; } = new HashSet<ColumnDto>(); 
    }
}
