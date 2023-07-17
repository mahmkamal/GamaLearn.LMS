using System.Linq.Expressions;
namespace GamaLearn.LMS.DataAccess.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        TEntity Add(TEntity entity);
        TEntity Find(params object[] predicate);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll();
        TEntity GetByID(Expression<Func<TEntity, bool>> predicate);
        TEntity Remove(TEntity entity);
    }

}
