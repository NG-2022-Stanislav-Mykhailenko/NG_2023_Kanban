namespace NG_2023_Kanban.BusinessLayer.Models
{
    public class CardModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AssignedId { get; set; }
        public int ColumnId { get; set; }
        public int SenderId { get; set; }

        public UserModel Assigned { get; set; }
        public ColumnModel Column { get; set; }
        public UserModel Sender { get; set; }

        public ICollection<CommentModel> Comments { get; set; } = new List<CommentModel>();
    }
}
