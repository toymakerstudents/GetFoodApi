
using GetFood.Entities.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Data.Abstract
{
    /// <summary>
    /// Represents generic repository for common data operations.
    /// </summary>
    /// <typeparam name="T">Entity Type</typeparam>
    public interface IRepository<T> where T: class,IEntityBase,new()
    {
        /// <summary>
        /// Returns collection of the specified entity
        /// </summary>
        /// <param name="filter">Filter for entitites, gets all of the entities if null</param>
        /// <returns>Collection of entities</returns>
        ICollection<T> GetAll(Expression<Func<T, bool>> filter = null);

        /// <summary>
        /// Returns the first entry by filter.
        /// </summary>
        /// <param name="filter">Filter for searching the entity.</param>
        /// <returns>The found entity or throws exception if not found</returns>
        T Get(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Adds the given entity to entity set.
        /// </summary>
        /// <param name="entity">Entity to add</param>
        /// <returns>Id of the entity</returns>
        int Add(T entity);

        /// <summary>
        /// Updates the given entity.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <returns>True if entity successfully updated, false otherwise</returns>
        bool Update(T entity);

        /// <summary>
        /// Deletes the given entity.
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        /// <returns>True if entity successfully deleted, false otherwise</returns>
        bool Delete(T entity);
    }
}
