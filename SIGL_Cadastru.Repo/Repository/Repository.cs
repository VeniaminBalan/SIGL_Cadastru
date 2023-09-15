using SIGL_Cadastru.Repo.Contracts;
using SIGL_Cadastru.Repo.DataBase;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class Repository<T> : IRepository<T> where T : class, IModel
{
    protected readonly AppDbContext _appDbContext;
    public Repository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public IQueryable<T> FindAll(bool trackChanges) =>
        !trackChanges ?
            _appDbContext.Set<T>()
                .AsNoTracking() :
            _appDbContext.Set<T>();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
        !trackChanges ?
            _appDbContext.Set<T>()
                .Where(expression)
                .AsNoTracking() :
            _appDbContext.Set<T>()
                .Where(expression);

    public void Create(T entity) => _appDbContext.Set<T>().Add(entity);
    public void Update(T entity) => _appDbContext.Set<T>().Update(entity);

    public async Task<T?> UpdateAsync(Guid id, object newEntity)
    {
        var entity = await GetAsync(id);
        if (entity is null) return null;

        CheckUpdateObject(entity, newEntity);
        await Save();

        return _appDbContext.Set<T>().First(e => e.Id == id);
    }

    public void Delete(T entity) => _appDbContext.Set<T>().Remove(entity);
    public void Detach(T entity) => _appDbContext.Entry(entity).State = EntityState.Detached;

    private Task<int> Save() => _appDbContext.SaveChangesAsync();
    private async Task<T?> GetAsync(Guid id)
    {
        return await _appDbContext.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
    }
    private static void CheckUpdateObject(T originalObj, object updateObj)
    {
        foreach (var property in updateObj.GetType().GetProperties())
        {
            var propValue = property.GetValue(updateObj, null);
            var originalProp = originalObj.GetType().GetProperty(property.Name);
            if (propValue is not null && originalProp is not null) originalProp.SetValue(originalObj, propValue);
        }
    }
}
