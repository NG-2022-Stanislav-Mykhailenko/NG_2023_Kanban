namespace NG_2023_Kanban.BusinessLayer.Models
{
    public class CommentModel : BaseModel
    {
        public string Text { get; set; }
        public int SenderId { get; set; }
        public int CardId { get; set; }

        public UserModel Sender { get; set; }
        public CardModel Card { get; set; }
    }
}
