using System.Linq.Expressions;

namespace HelpURL.Domain.Core.Interfaces;

public interface IBaseRepository<T>
{
    Task<IEnumerable<T>> GetAll();
    Task<T> Insert(T entity);
    Task<T> Update(T entity);
    Task<bool> Delete(T entity);
    Task<T> GetOneWhere(Expression<Func<T, bool>> condition);
}
