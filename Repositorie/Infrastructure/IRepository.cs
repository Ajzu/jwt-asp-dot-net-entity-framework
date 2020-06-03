using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositorie.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        T Add(T t);
        Task<T> AddAsyn(T t);
        void Save();
        Task<int> SaveAsync();

        T Update(T t, object key);
        Task<T> UpdateAsync(T t, object key);

        void Delete(T entity);
        Task<int> DeleteAsyn(T entity);

        T Get(int id);
        T GetByGuid(Guid id);
        Task<T> GetByGuidAsync(Guid id);
        IQueryable<T> GetAll();
        Task<ICollection<T>> GetAllAsyn();
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetAsync(int id);


      

        T Find(Expression<Func<T, bool>> match);
        ICollection<T> FindAll(Expression<Func<T, bool>> match);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<ICollection<T>> FindByAsyn(Expression<Func<T, bool>> predicate);

       

        int Count();
        Task<int> CountAsync();

        void Dispose();


    }
}