using NG_2023_Kanban.BusinessLayer.Models;

namespace NG_2023_Kanban.BusinessLayer.Interfaces
{
    public interface IUserService
    {
        Task<UserModel?> LoginAsync(UserModel user);
        Task<UserModel> RegisterAsync(UserModel user);
    }
}
