using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace SIGL_Cadastru.Repo.Contracts
{
    public interface IRepository<T> where T : class, IModel
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        Task<T?> UpdateAsync(Guid id, object entity);
        void Delete(T entity);
        void Detach(T entity);
    }
}
