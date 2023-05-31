using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using SIGL_Cadastru.Repo.Models;


namespace SIGL_Cadastru.Repo.Repository
{
    public interface IRepository<T> where T : class, IModel
    {
        DbSet<T> DbSet { get; }
        Task<T> AddAsync([NotNull] T entity);
        Task<T?> GetAsync(string id);
        Task<IEnumerable<T>> GetAsync();
        Task<T?> AddOrUpdateAsync([NotNull] T entity);
        Task<T?> UpdateAsync(string id, object entity);
        Task<T?> DeleteAsync(string id);
        Task<IEnumerable<T>> DeleteAsync(IEnumerable<string> ids);

        T Add([NotNull] T entity);
        IEnumerable<T> Get();
    }
}
