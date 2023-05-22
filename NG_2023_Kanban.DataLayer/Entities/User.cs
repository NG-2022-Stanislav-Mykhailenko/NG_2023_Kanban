namespace NG_2023_Kanban.DataLayer.Entities
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Board>? Boards { get; set; } = new HashSet<Board>();
        public virtual ICollection<Card>? CardsAssigned { get; set; } = new HashSet<Card>();
        public virtual ICollection<Comment>? Comments { get; set; } = new HashSet<Comment>();
        public virtual ICollection<Card>? CardsSent { get; set; } = new HashSet<Card>();
        public virtual ICollection<Role>? Roles { get; set; } = new HashSet<Role>();
    }
}
