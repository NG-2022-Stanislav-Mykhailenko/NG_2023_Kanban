namespace NG_2023_Kanban.BusinessLayer.Models
{
    public class RoleModel : BaseModel
    {
        public string Name { get; set; }

        public virtual ICollection<UserModel>? Members { get; set; } = new HashSet<UserModel>();
    }
}
