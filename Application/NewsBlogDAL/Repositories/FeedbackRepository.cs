using NewsBlogDAL.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace NewsBlogDAL.Repositories
{
    /// <summary>
    /// Interaction with feedbacks
    /// </summary>
    public class FeedbackRepository : IRepository<Feedback>
    {
        /// <summary>
        /// Database context
        /// </summary>
        private readonly NewsBlogContext _newsBlogContext;

        /// <summary>
        /// Connect to database context
        /// </summary>
        /// <param name="newsBlogContext"></param>
        public FeedbackRepository(NewsBlogContext newsBlogContext)
        {
            _newsBlogContext = newsBlogContext;
        }

        /// <summary>
        /// Create new feedback
        /// </summary>
        /// <param name="feedback"></param>
        /// <returns>feedback</returns>
        public async Task<Feedback> CreateAsync(Feedback feedback)
        {
            _newsBlogContext.Feedbacks.Add(feedback);
            await _newsBlogContext.SaveChangesAsync();
            return feedback;
        }

        /// <summary>
        /// Delete feedback by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>delete result</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var feedback = _newsBlogContext.Feedbacks.Attach(new Feedback { Id = id });
            bool isNull = feedback == null;
            if (!isNull)
            {
                _newsBlogContext.Entry(feedback).State = EntityState.Deleted;
                await _newsBlogContext.SaveChangesAsync();
            }
            return !isNull;
        }

        /// <summary>
        /// Get all feedbacks
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Feedback>> GetAllAsync()
        {
            return await _newsBlogContext.Feedbacks.ToListAsync();
        }

        /// <summary>
        /// Get feedback by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Feedback> GetByIdAsync(int id)
        {
            return await _newsBlogContext.Feedbacks.FindAsync(id);
        }

        /// <summary>
        /// Update feedback
        /// </summary>
        /// <param name="feedback">new feedback</param>
        /// <returns>update result</returns>
        public async Task<bool> UpdateAsync(Feedback feedback)
        {
            var newFeedback = _newsBlogContext.Feedbacks.Attach(feedback);
            _newsBlogContext.Entry(feedback).State = EntityState.Modified;
            await _newsBlogContext.SaveChangesAsync();
            return newFeedback != null;
        }
    }
}