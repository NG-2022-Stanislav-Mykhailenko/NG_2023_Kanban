namespace NG_2023_Kanban.DataLayer.Entities
{
    public class Column : BaseEntity
    {
        public string Name { get; set; }
        public int BoardId { get; set; }

        public Board Board { get; set; }

        public ICollection<Card> Cards { get; set; } = new List<Card>();
    }
}
