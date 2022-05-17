using GradeManagementModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GradeManagementData.Abstract
{
    public interface IBaseRepository<T> where T : class, IBaseEntity
    {
        Task<bool> Add(T entity);
        Task<bool> AddRange(List<T> entities);
        Task<bool> Any(Expression<Func<T, bool>> expression);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAll();
        Task<List<T>> GetAll(Expression<Func<T, bool>> expression);
        Task<T> Get(Expression<Func<T, bool>> expression);
        Task<T> GetByID(Guid id);
        Task<int> Save();
    }
}
