using NG_2023_Kanban.DataLayer.DbStartup;
using NG_2023_Kanban.DataLayer.Entities;
using NG_2023_Kanban.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NG_2023_Kanban.DataLayer.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(DatabaseContext context) : base(context) { }

    public async Task<ICollection<User>> GetAllAsync()
        => await _context.Set<User>().Select(x => x).
           Include(x => x.Boards).
           Include(x => x.CardsAssigned).
           Include(x => x.CardsSent).
           Include(x => x.Comments).
           Include(x => x.Roles).
           ToListAsync();

    public async Task<User> GetAsync(int id)
        => await _context.Set<User>().
           Include(x => x.Boards).
           Include(x => x.CardsAssigned).
           Include(x => x.CardsSent).
           Include(x => x.Comments).
           Include(x => x.Roles).
           FirstAsync(x => x.Id == id);
}
