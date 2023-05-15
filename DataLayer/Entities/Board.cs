namespace NG_2023_Kanban.DataLayer.Entities
{
    public class Board : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<User>? Users { get; set; } = new HashSet<User>();

        public virtual ICollection<Column>? Columns { get; set; } = new HashSet<Column>(); 
    }
}
