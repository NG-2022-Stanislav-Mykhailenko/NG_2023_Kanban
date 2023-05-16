using NG_2023_Kanban.DataLayer.DbStartup;
using NG_2023_Kanban.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace NG_2023_Kanban.DataLayer.Service
{
    public class DataService
    {
        private readonly DatabaseContext _context;
        public DataService(DatabaseContext context) 
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task<User> AddAsync(User entity)
        {
            await _context.Set<User>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var entity = await _context.Set<User>().FirstOrDefaultAsync(x => x.Id == id);
            
            return entity;
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            User? entity = await _context.Set<User>().FirstOrDefaultAsync(x => x.Username == username);

            if (entity != null && entity.Password == password) // TODO: hashing
                return entity;
            return null;
        }

        public async Task<ICollection<User>> GetAllAsync()
        {
            var entities = await _context.Set<User>().Select(x => x).ToListAsync();

            return entities;
        }

        public async Task UpdateAsync(User model)
        {
            _context.Set<User>().Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User model) 
        {
            _context.Set<User>().Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}
