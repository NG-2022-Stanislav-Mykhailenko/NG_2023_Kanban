namespace NG_2023_Kanban.DTOs
{
    public class CommentDto : BaseDto
    {
        public string Text { get; set; }
        public int SenderId { get; set; }
        public int CardId { get; set; }

        public UserDto Sender { get; set; }
        public CardDto Card { get; set; }
    }
}
