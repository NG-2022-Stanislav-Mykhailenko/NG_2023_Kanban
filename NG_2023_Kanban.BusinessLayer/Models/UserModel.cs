namespace NG_2023_Kanban.BusinessLayer.Models
{
    public class UserModel : BaseModel
    {
        public string FullName { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<BoardModel> Boards { get; set; } = new List<BoardModel>();
        public ICollection<CardModel> CardsAssigned { get; set; } = new List<CardModel>();
        public ICollection<CardModel> CardsSent { get; set; } = new List<CardModel>();
        public ICollection<CommentModel> Comments { get; set; } = new List<CommentModel>();
        public ICollection<RoleModel> Roles { get; set; } = new List<RoleModel>();
    }
}
