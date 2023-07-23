namespace NG_2023_Kanban.DataLayer.Entities
{
    public class Card : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AssignedId { get; set; }
        public int ColumnId { get; set; }
        public int SenderId { get; set; }

        public User Assigned { get; set; }
        public Column Column { get; set; }
        public User Sender { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
