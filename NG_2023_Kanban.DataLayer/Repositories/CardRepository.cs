using NG_2023_Kanban.DataLayer.DbStartup;
using NG_2023_Kanban.DataLayer.Entities;
using NG_2023_Kanban.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NG_2023_Kanban.DataLayer.Repositories;

public class CardRepository : BaseRepository<Card>, ICardRepository
{
    public CardRepository(DatabaseContext context) : base(context) { }

    public async Task<ICollection<Card>> GetAllAsync()
        => await _context.Set<Card>().Select(x => x).
           Include(x => x.Comments).
           ToListAsync();

    public async Task<Card> GetAsync(int id)
        => await _context.Set<Card>().
           Include(x => x.Comments).
           FirstAsync(x => x.Id == id);
}
