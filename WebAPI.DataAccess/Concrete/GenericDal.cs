using Microsoft.EntityFrameworkCore;
using WebAPI.DataAccess.Abstract;
using WebAPI.DataAccess.Data;

namespace WebAPI.DataAccess.Concrete;

public class GenericDal<T> : IGenericDal<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public GenericDal(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task CreateAsync(T t)
    {
        await _context.Set<T>().AddAsync(t);
        await _context.SaveChangesAsync();
    }

    public async Task<T> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<T>> GetAllListAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIDAsync(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public Task UpdateAsync(T t, Guid id)
    {
        throw new NotImplementedException();
    }
}