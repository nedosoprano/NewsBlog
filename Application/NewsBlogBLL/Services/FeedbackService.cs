using NewsBlogDAL.Models;
using NewsBlogDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NewsBlogBLL.Services
{
    /// <summary>
    /// Interaction with feedbscks repository
    /// </summary>
    public class FeedbackService : IService<Feedback>
    {
        /// <summary>
        /// feedback repository
        /// </summary>
        private readonly IRepository<Feedback> _feedbackRepository;

        public FeedbackService() { }

        /// <summary>
        /// Connect to repository
        /// </summary>
        /// <param name="feedbackRepository"></param>
        public FeedbackService(IRepository<Feedback> feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        /// <summary>
        /// Create new feedback
        /// </summary>
        /// <param name="feedback"></param>
        /// <returns>feedback</returns>
        public async Task<Feedback> CreateAsync(Feedback feedback)
        {
            Regex nameValidation = new Regex(@"^[A-Z]{1}[a-z]+$");
            if (feedback == null || 
                !nameValidation.IsMatch(feedback.AuthorName))
                throw new ArgumentException();
            return await _feedbackRepository.CreateAsync(feedback);
        }

        /// <summary>
        /// Get all feedbacks
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Feedback>> GetAllAsync()
        {
            return await _feedbackRepository.GetAllAsync();
        }

        /// <summary>
        /// Get feedback by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Feedback> GetByIdAsync(int id)
        {
            return await _feedbackRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Update feedback
        /// </summary>
        /// <param name="feedback">new feedback</param>
        /// <returns>update result</returns>
        public async Task<bool> UpdateAsync(Feedback feedback)
        {
            if (feedback == null) throw new ArgumentNullException();
            return await _feedbackRepository.UpdateAsync(feedback);
        }

        /// <summary>
        /// Delete feedback by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>delete feedback</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            return await _feedbackRepository.DeleteAsync(id);
        }
    }
}