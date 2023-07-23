using NG_2023_Kanban.DataLayer.DbStartup;
using NG_2023_Kanban.DataLayer.Entities;
using NG_2023_Kanban.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace NG_2023_Kanban.DataLayer.Repositories;

public class BaseRepository<T> : IRepository<T> where T : BaseEntity
{
    protected DatabaseContext _context;

    public BaseRepository(DatabaseContext context)
        => _context = context;

    public async Task<ICollection<T>> GetAllAsync()
        => await _context.Set<T>().Select(x => x).ToListAsync();

    public async Task<T> GetAsync(int id)
        => await _context.Set<T>().FirstAsync(x => x.Id == id);

    public async Task<ICollection<T>> FindAsync(Func<T, bool> predicate)
    {
        var entities = await GetAllAsync();
        return entities.Where(predicate).ToList();
    }

    public async Task CreateAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, T entity)
    {
        var updated = await GetAsync(id);
        foreach (PropertyInfo propertyInfo in entity.GetType().GetProperties())
        {
            string name = propertyInfo.Name;
            var value = propertyInfo.GetValue(entity);
            if (value != null)
            {
                PropertyInfo setProperty = updated.GetType().GetProperty(name);
                setProperty.SetValue(updated, value);
            }
        }
        //_context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetAsync(id);
        await DeleteAsync(entity);
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}
