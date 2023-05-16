namespace NG_2023_Kanban.DataLayer.Entities
{
    public class Column : BaseEntity
    {
        public string Name { get; set; }
        public int BoardId { get; set; }

        public virtual Board Board { get; set; }

        public virtual ICollection<Card>? Cards { get; set; } = new HashSet<Card>();
    }
}
