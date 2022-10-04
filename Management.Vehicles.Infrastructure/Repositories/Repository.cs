using Management.Vehicles.Core.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Management.Vehicles.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly VehicleDBContext _context;

    public Repository(VehicleDBContext context)
     => _context = context;

    public async Task<IReadOnlyList<T>> GetAllAsync()
     => await _context.Set<T>().ToListAsync();

    public async Task<T> GetByIdAsync(Guid id)
        => await _context.Set<T>().FindAsync(id);

    public async Task<T> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}
