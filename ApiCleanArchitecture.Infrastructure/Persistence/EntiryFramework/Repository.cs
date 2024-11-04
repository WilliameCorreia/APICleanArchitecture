using ApiCleanArchitecture.Domain.IRepositories;
using ApiCleanArchitecture.Infrastructure.Persistence.EntiryFramework.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiCleanArchitecture.Infrastructure.Persistence.EntiryFramework
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _applicationDbContext;
        protected readonly DbSet<TEntity> _dbSet;

        protected Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _dbSet = _applicationDbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            //_dbSet.Add(entity);
            _applicationDbContext.Add(entity);
            _applicationDbContext.SaveChanges();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            try
            {
                _applicationDbContext.Attach(entity).State = EntityState.Added;
                var obj = await _applicationDbContext.Set<TEntity>().AddAsync(entity);
                _applicationDbContext.SaveChanges();

                return obj.Entity;
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public virtual void Dispose()
        {
            _applicationDbContext.Dispose();
        }

        public virtual IQueryable<TEntity> GetAllSoftDeleted()
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetByIdAsync<TKey>(TKey id) where TKey : IEquatable<TKey>
        {
            var obj = await _applicationDbContext.Set<TEntity>().FindAsync(id);

            return obj;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _applicationDbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<int> RemoveAsync(TEntity entity)
        {
            _applicationDbContext.Set<TEntity>().Remove(entity);

            return await _applicationDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            try
            {
                _applicationDbContext.Attach(entity).State = EntityState.Modified;
                _applicationDbContext.Set<TEntity>().Update(entity);
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ex.ToString();
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public virtual void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveChanges()
        {
            return await _applicationDbContext.SaveChangesAsync();
        }

        public virtual void Update(TEntity obj)
        {
            _dbSet.Update(obj);
        }

        public virtual TEntity GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
