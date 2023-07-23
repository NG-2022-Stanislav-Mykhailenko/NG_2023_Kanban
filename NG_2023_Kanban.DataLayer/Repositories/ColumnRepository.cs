using NG_2023_Kanban.DataLayer.DbStartup;
using NG_2023_Kanban.DataLayer.Entities;
using NG_2023_Kanban.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NG_2023_Kanban.DataLayer.Repositories;

public class ColumnRepository : BaseRepository<Column>, IColumnRepository
{
    public ColumnRepository(DatabaseContext context) : base(context) { }

    public async Task<ICollection<Column>> GetAllAsync()
        => await _context.Set<Column>().Select(x => x).
           Include(x => x.Cards).
           ToListAsync();

    public async Task<Column> GetAsync(int id)
        => await _context.Set<Column>().
           Include(x => x.Cards).
           FirstAsync(x => x.Id == id);
}
