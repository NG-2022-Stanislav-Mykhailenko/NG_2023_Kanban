using NG_2023_Kanban.DataLayer.DbStartup;
using NG_2023_Kanban.DataLayer.Entities;
using NG_2023_Kanban.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NG_2023_Kanban.DataLayer.Repositories;

public class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    public RoleRepository(DatabaseContext context) : base(context) { }

    public async Task<ICollection<Role>> GetAllAsync()
        => await _context.Set<Role>().Select(x => x).
           Include(x => x.Members).
           ToListAsync();

    public async Task<Role> GetAsync(int id)
        => await _context.Set<Role>().
           Include(x => x.Members).
           FirstAsync(x => x.Id == id);
}
