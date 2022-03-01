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
    /// <summary>
    /// Absract Repository Base that usable with EfCore
    /// </summary>
    /// <typeparam name="T">Entity Type</typeparam>
    public abstract class EntityFrameworkRepositoryBase<T> : IRepository<T> where T : class, IEntityBase, new()
    {
        DbContext _dbContext;

        /// <summary>
        /// Primary Key Name of the entity
        /// </summary>
        string keyname;

        /// <summary>
        /// Constructor with DbContext
        /// </summary>
        /// <param name="dbContext">DbContext that given by IoC</param>
        public EntityFrameworkRepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
            keyname = dbContext.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.Select(x => x.Name).Single();
        }

        /// <summary>
        /// Adds the given entity to entity set.
        /// </summary>
        /// <param name="entity">Entity to add</param>
        /// <returns>Id of the entity</returns>
        public virtual int Add(T entity)
        {
            var entityToAdd = _dbContext.Entry(entity);
            entityToAdd.State = EntityState.Added;
            _dbContext.SaveChanges();

            //Returns the primary key value.
            return (int) entityToAdd.Entity.GetType().GetProperty(keyname).GetValue(entity,null);
        }

        /// <summary>
        /// Deletes the given entity.
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        /// <returns>True if entity successfully deleted, false otherwise</returns>
        public virtual bool Delete(T entity)
        {
            var entityToDelete = _dbContext.Entry(entity);
            entityToDelete.State = EntityState.Deleted;
            int numberOfChanges =_dbContext.SaveChanges();

            //Returns true if any changes on the database from last execution.
            return numberOfChanges > 0;
        }

        /// <summary>
        /// Returns the first entry by filter.
        /// </summary>
        /// <param name="filter">Filter for searching the entity.</param>
        /// <returns>The found entity or throws exception if not found</returns>
        public virtual T Get(Expression<Func<T, bool>> filter)
        {
            //GetAll
            var query = GetAll(filter).SingleOrDefault();
            return query;
        }

        /// <summary>
        /// Returns cquery of the specified entity
        /// </summary>
        /// <param name="filter">Filter for entitites, gets all of the entities if null</param>
        /// <returns>Query of entities</returns>
        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            //Define the query
            var query = filter == null ? _dbContext.Set<T>() :
                  _dbContext.Set<T>().Where(filter);
            //Finds all of the property of given model
            var navigations = _dbContext.Model.FindEntityType(typeof(T)).GetDerivedTypesInclusive().SelectMany(type => type.GetNavigations()).Distinct();
            //Includes Properties
            foreach (var property in navigations)
            {
                query = query.Include(property.Name);
            }
            return query;
        }
        /// <summary>
        /// Returns entitiy collection without a condition
        /// </summary>
        /// <returns>Collection of entities</returns>
        public virtual ICollection<T> GetAll()
        {
            return GetAll(null).ToList();
        }

        public virtual bool Update(T entity)
        {
            var updatedEntity = _dbContext.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            int numberOfChanges =_dbContext.SaveChanges();

            return numberOfChanges > 0;
        }
    }
}
