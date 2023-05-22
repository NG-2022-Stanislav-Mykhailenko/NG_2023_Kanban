namespace NG_2023_Kanban.DTOs
{
    public class RoleDto : BaseDto
    {
        public string Name { get; set; }

        public virtual ICollection<UserDto>? Members { get; set; } = new HashSet<UserDto>();
    }
}
