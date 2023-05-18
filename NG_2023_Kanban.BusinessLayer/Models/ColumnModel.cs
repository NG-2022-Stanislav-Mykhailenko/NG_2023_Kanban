namespace NG_2023_Kanban.BusinessLayer.Models
{
    public class ColumnModel : BaseModel
    {
        public string Name { get; set; }
        public int BoardId { get; set; }

        public virtual BoardModel Board { get; set; }

        public virtual ICollection<CardModel>? Cards { get; set; } = new HashSet<CardModel>();
    }
}
