using NG_2023_Kanban.DataLayer.DbStartup;
using NG_2023_Kanban.DataLayer.Entities;
using NG_2023_Kanban.DataLayer.Interfaces;

namespace NG_2023_Kanban.DataLayer.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(DatabaseContext context) : base(context) { }
}
