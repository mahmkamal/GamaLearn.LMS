using GamaLearn.LMS.DataAccess;
using GamaLearn.LMS.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Ninject.Activation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GamaLearn.LMS.DataAccess.Repository
{

    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        DbSet<TEntity> dbSet;
        LMSDbContext db;

        public RepositoryBase(LMSDbContext dbContext)
        {
            db = dbContext;
            dbSet = dbContext.Set<TEntity>();
        }
        public TEntity Add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
            return entity;
        }

        public TEntity Find(params object[] predicate)
        {
            return dbSet.Find(predicate);
        }
        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }
        public IQueryable<TEntity> GetAll()
        {
            return dbSet;
        }
        public int GetCountAllWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate).Count();
        }
        public List<TEntity> GetAllByStatusID(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }
        public List<TEntity> GetAllByID(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }
        public TEntity GetByID(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate).FirstOrDefault();
        }
        public int GetAllCount()
        {
            return dbSet.Count();
        }
        public TEntity Remove(TEntity entity)
        {
            dbSet.Remove(entity);
            return entity;
        }


    }
}
