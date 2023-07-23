namespace NG_2023_Kanban.DataLayer.Entities
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<Board> Boards { get; set; } = new List<Board>();
        public ICollection<Card> CardsAssigned { get; set; } = new List<Card>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Card> CardsSent { get; set; } = new List<Card>();
        public ICollection<Role> Roles { get; set; } = new List<Role>();
    }
}
