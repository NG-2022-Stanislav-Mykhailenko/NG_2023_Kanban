using NG_2023_Kanban.DataLayer.Entities;

namespace NG_2023_Kanban.BusinessLayer.Interfaces
{
    public interface IUserService
    {
        Task<User> LoginAsync(User user);
        Task<User> RegisterAsync(User user);
    }
}
