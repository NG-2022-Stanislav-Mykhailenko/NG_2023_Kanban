namespace NG_2023_Kanban.Entities
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; }
        public int SenderId { get; set; }
        public int CardId { get; set; }

        public virtual User? Sender { get; set; }
        public virtual Card? Card { get; set; }
    }
}
