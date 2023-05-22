using NG_2023_Kanban.BusinessLayer.Models;

namespace NG_2023_Kanban.BusinessLayer.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> GetAsync(int id);
        Task<ICollection<UserModel>> GetAllAsync();
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, UserModel user);
        Task<UserModel?> LoginAsync(UserModel user);
        Task<UserModel> RegisterAsync(UserModel user);
        Task<bool> CheckAdminAsync(int id);
    }
}
