namespace WebAPI.DataAccess.Abstract;

public interface IGenericDal<T> where T : class
{
    Task<List<T>> GetAllListAsync();
    Task<T?> GetByIDAsync(Guid id);
    Task CreateAsync(T t);

    Task UpdateAsync(T t, Guid id);
    Task<T> DeleteAsync(Guid id);
}
