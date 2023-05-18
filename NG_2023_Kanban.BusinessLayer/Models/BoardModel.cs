namespace NG_2023_Kanban.BusinessLayer.Models
{
    public class BoardModel : BaseModel
    {
        public string Name { get; set; }

        public virtual ICollection<UserModel>? Users { get; set; } = new HashSet<UserModel>();

        public virtual ICollection<ColumnModel>? Columns { get; set; } = new HashSet<ColumnModel>(); 
    }
}
