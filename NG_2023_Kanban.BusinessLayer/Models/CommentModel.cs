namespace NG_2023_Kanban.BusinessLayer.Models
{
    public class CommentModel : BaseModel
    {
        public string Text { get; set; }
        public int SenderId { get; set; }
        public int CardId { get; set; }

        public virtual UserModel? Sender { get; set; }
        public virtual CardModel? Card { get; set; }
    }
}
