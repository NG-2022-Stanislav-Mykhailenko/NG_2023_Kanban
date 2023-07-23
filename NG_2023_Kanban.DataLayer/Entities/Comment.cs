namespace NG_2023_Kanban.DataLayer.Entities
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; }
        public int SenderId { get; set; }
        public int CardId { get; set; }

        public User Sender { get; set; }
        public Card Card { get; set; }
    }
}
