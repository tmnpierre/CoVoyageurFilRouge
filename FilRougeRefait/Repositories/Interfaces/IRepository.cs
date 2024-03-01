using System.Linq.Expressions;

namespace CoVoyageur.API.Repositories.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity?> GetById(int id);
        Task<TEntity?> Get(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity?> Add(TEntity entity);
        Task<TEntity?> Update(TEntity entity);
        Task<bool> Delete(int id);
    }
}