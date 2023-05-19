using NG_2023_Kanban.BusinessLayer.Models;

namespace NG_2023_Kanban.BusinessLayer.Interfaces
{
    public interface IBoardService
    {
        Task<BoardModel> GetAsync(int id);
        Task<ICollection<BoardModel>> GetAllAsync();
    }
}
