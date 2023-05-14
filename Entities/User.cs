namespace NG_2023_Kanban.Entities
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public virtual ICollection<Board>? Boards { get; set; } = new HashSet<Board>();
        public virtual ICollection<Card>? Cards { get; set; } = new HashSet<Card>();
        public virtual ICollection<Comment>? Comments { get; set; } = new HashSet<Comment>();
    }
}
