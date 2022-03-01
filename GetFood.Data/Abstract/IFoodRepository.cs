using GetFood.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFood.Data.Abstract
{
    /// <summary>
    /// Represents Food Repository Interface
    /// </summary>
    public interface IFoodRepository:IRepository<Food>
    {
        /// <summary>
        /// Gets All Foods by Restaurant Id
        /// </summary>
        /// <param name="restaurantId">Id of the Restaurant to get</param>
        /// <returns>Collection of foods</returns>
        ICollection<Food> GetAllByRestaurantId(int restaurantId);
    }
}
