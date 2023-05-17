using NG_2023_Kanban.DataLayer.DbStartup;
using NG_2023_Kanban.DataLayer.Entities;
using NG_2023_Kanban.DataLayer.Interfaces;

namespace NG_2023_Kanban.DataLayer.Repositories;

public class CardRepository : BaseRepository<Card>, ICardRepository
{
    public CardRepository(DatabaseContext context) : base(context) { }
}
