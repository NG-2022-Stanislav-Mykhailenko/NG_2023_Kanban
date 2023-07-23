namespace NG_2023_Kanban.BusinessLayer.Models
{
    public class ColumnModel : BaseModel
    {
        public string Name { get; set; }
        public int BoardId { get; set; }

        public BoardModel Board { get; set; }

        public ICollection<CardModel> Cards { get; set; } = new List<CardModel>();
    }
}
