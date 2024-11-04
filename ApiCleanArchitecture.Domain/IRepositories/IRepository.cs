using System.Linq.Expressions;

namespace ApiCleanArchitecture.Domain.IRepositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity entity);

        Task<TEntity> AddAsync(TEntity entity);

        TEntity GetById(Guid id);

        IQueryable<TEntity> GetAllSoftDeleted();

        void Update(TEntity obj);

        void Remove(Guid id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetByIdAsync<TKey>(TKey id) where TKey : IEquatable<TKey>;

        Task<int> SaveChanges();

        Task<int> RemoveAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);
    }
}
