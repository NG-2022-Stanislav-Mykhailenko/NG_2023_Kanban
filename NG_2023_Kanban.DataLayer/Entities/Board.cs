namespace NG_2023_Kanban.DataLayer.Entities
{
    public class Board : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();

        public ICollection<Column> Columns { get; set; } = new List<Column>();
    }
}
