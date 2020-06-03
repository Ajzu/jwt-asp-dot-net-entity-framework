
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositorie.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        

        private DataBaseContext dbContext;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }
        protected DataBaseContext DbContext
        {
            get { return dbContext ?? (dbContext = DbFactory.Init()); }
        }
        public RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
        }
        public RepositoryBase()
        {
            dbContext = new DataBaseContext();
        }
        public IQueryable<T> GetAll()
        {
            return dbContext.Set<T>();
        }
        public virtual async Task<ICollection<T>> GetAllAsyn()
        {

            return await dbContext.Set<T>().ToListAsync();
        }
        public virtual T Get(int id)
        {
            return dbContext.Set<T>().Find(id);
        }
        public virtual T GetByGuid(Guid id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public virtual async Task<T> GetByGuidAsync(Guid id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }
        public virtual T Add(T t)
        {

            dbContext.Set<T>().Add(t);
            dbContext.SaveChanges();
            return t;
        }

        public virtual async Task<T> AddAsyn(T t)
        {
            dbContext.Set<T>().Add(t);
            await dbContext.SaveChangesAsync();
            return t;

        }

        public virtual T Find(Expression<Func<T, bool>> match)
        {
            return dbContext.Set<T>().SingleOrDefault(match);
        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await dbContext.Set<T>().SingleOrDefaultAsync(match);
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            return dbContext.Set<T>().Where(match).ToList();
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await dbContext.Set<T>().Where(match).ToListAsync();
        }

        public virtual void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            dbContext.SaveChanges();
        }

        public virtual async Task<int> DeleteAsyn(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            return await dbContext.SaveChangesAsync();
        }

        public virtual T Update(T t, object key)
        {
            if (t == null)
                return null;
            T exist = dbContext.Set<T>().Find(key);
            if (exist != null)
            {
                dbContext.Entry(exist).CurrentValues.SetValues(t);
                dbContext.SaveChanges();
            }
            return exist;
        }

        public virtual async Task<T> UpdateAsync(T t, object key)
        {
            if (t == null)
                return null;
            T exist = await dbContext.Set<T>().FindAsync(key);
            if (exist != null)
            {
                dbContext.Entry(exist).CurrentValues.SetValues(t);
                await dbContext.SaveChangesAsync();
            }
            return exist;
        }

        public int Count()
        {
            return dbContext.Set<T>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await dbContext.Set<T>().CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> match)
        {
            return await dbContext.Set<T>().CountAsync(match);
        }


        public virtual void Save()
        {

            dbContext.SaveChanges();
        }

        public async virtual Task<int> SaveAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = dbContext.Set<T>().Where(predicate);
            return query;
        }

        public virtual async Task<ICollection<T>> FindByAsyn(Expression<Func<T, bool>> predicate)
        {
            return await dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {

            IQueryable<T> queryable = GetAll();
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {

                queryable = queryable.Include<T, object>(includeProperty);
            }

            return queryable;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

