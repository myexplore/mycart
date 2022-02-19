using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ServiceLibrary.Contract
{
    public interface IRepository<T>
    {
        //IQueryable<T> Query();
        //IQueryable<T> Query(Expression<Func<T, bool>> expression);

        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
        //Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
        //                                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        //                                string includeString = null,
        //                                bool disableTracking = true);
        //Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
        //                               Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        //                               List<Expression<Func<T, object>>> includes = null,
        //                               bool disableTracking = true);
        Task<T> GetByIdAsync(string id);
        Task AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}
