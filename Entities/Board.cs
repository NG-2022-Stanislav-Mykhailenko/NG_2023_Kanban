namespace NG_2023_Kanban.Entities
{
    public class Board : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<User>? Users { get; set; } = new HashSet<User>();

        public virtual ICollection<Card>? Cards { get; set; } = new HashSet<Card>(); 
    }
}
