using NG_2023_Kanban.DataLayer.DbStartup;
using NG_2023_Kanban.DataLayer.Entities;
using NG_2023_Kanban.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NG_2023_Kanban.DataLayer.Repositories;

public class BoardRepository : BaseRepository<Board>, IBoardRepository
{
    public BoardRepository(DatabaseContext context) : base(context) { }

    public async Task<ICollection<Board>> GetAllAsync()
        => await _context.Set<Board>().Select(x => x).
           Include(x => x.Users).
           Include(x => x.Columns).
           ToListAsync();

    public async Task<Board> GetAsync(int id)
        => await _context.Set<Board>().
           Include(x => x.Users).
           Include(x => x.Columns).
           FirstAsync(x => x.Id == id);
}
