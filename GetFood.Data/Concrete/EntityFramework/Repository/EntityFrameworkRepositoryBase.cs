using GetFood.Data.Abstract;
using GetFood.Entities.IBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Data.Concrete.EntityFramework.Repository
{
    public abstract class EntityFrameworkRepositoryBase<T> : IRepository<T> where T : class, IEntityBase, new()
    {
        DbContext _dbContext;
        string keyname;
        public EntityFrameworkRepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
            keyname = dbContext.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.Select(x => x.Name).Single();
        }
        public int Add(T entity)
        {
            var entityToAdd = _dbContext.Entry(entity);
            entityToAdd.State = EntityState.Added;
            _dbContext.SaveChanges();

            return (int) entityToAdd.Entity.GetType().GetProperty(keyname).GetValue(entity,null);
        }

        public bool Delete(T entity)
        {
            var entityToDelete = _dbContext.Entry(entity);
            entityToDelete.State = EntityState.Deleted;
            int numberOfChanges =_dbContext.SaveChanges();

            return numberOfChanges > 0;
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _dbContext.Set<T>().SingleOrDefault(filter);
        }

        public ICollection<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? _dbContext.Set<T>().ToList() :
                  _dbContext.Set<T>().Where(filter).ToList();
        }

        public bool Update(T entity)
        {
            var updatedEntity = _dbContext.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            int numberOfChanges =_dbContext.SaveChanges();

            return numberOfChanges > 0;
        }
    }
}
