using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsBlogBLL.Services
{
    /// <summary>
    /// Interaction with repositories
    /// </summary>
    /// <typeparam name="T">Model type</typeparam>
    public interface IService<T>
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
        /// Delete item
        /// </summary>
        /// <param name="id">item id</param>
        /// <returns>delete result</returns>
        Task<bool> DeleteAsync(int id);
    }
}
