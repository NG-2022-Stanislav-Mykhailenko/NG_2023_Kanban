namespace NG_2023_Kanban.DataLayer.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<User> Members { get; set; } = new List<User>();
    }
}
