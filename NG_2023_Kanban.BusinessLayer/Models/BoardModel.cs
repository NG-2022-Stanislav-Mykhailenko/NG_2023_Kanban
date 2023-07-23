namespace NG_2023_Kanban.BusinessLayer.Models
{
    public class BoardModel : BaseModel
    {
        public string Name { get; set; }

        public ICollection<UserModel> Users { get; set; } = new List<UserModel>();

        public ICollection<ColumnModel> Columns { get; set; } = new List<ColumnModel>();
    }
}
