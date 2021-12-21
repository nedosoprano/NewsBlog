using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsBlogDAL.Repositories
{
    /// <summary>
    /// Interaction to database context
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Create item
        /// </summary>
        /// <param name="item"></param>
        /// <returns>item</returns>
        Task<T> CreateAsync(T item);

        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Get item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Update item
        /// </summary>
        /// <param name="item">new item</param>
        /// <returns>update result</returns>
        Task<bool> UpdateAsync(T item);

        /// <summary>
        /// Delete item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>delete result</returns>
        Task<bool> DeleteAsync(int id);
    }
}