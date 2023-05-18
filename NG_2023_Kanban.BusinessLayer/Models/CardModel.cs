namespace NG_2023_Kanban.BusinessLayer.Models
{
    public class CardModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int SenderId { get; set; }
        public int ColumnId { get; set; }

        public virtual UserModel Sender { get; set; }
        public virtual ColumnModel Column { get; set; }

        public virtual ICollection<CommentModel> Comments { get; set; } = new HashSet<CommentModel>();
    }
}
