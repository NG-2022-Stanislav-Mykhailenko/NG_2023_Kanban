namespace NG_2023_Kanban.DataLayer.Entities
{
    public class Card : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int SenderId { get; set; }
        public int ColumnId { get; set; }

        public virtual User Sender { get; set; }
        public virtual Column Column { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
