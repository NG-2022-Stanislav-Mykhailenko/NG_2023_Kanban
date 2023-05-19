using NG_2023_Kanban.BusinessLayer.Models;

namespace NG_2023_Kanban.BusinessLayer.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> GetAsync(int id);
        Task<ICollection<UserModel>> GetAllAsync();
        Task<UserModel?> LoginAsync(UserModel user);
        Task<UserModel> RegisterAsync(UserModel user);
    }
}
