using NewsBlogDAL.Models;
using NewsBlogDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NewsBlogBLL.Services
{
    /// <summary>
    /// Interaction with questionnaire result repository
    /// </summary>
    public class QuestionnaireResultService : IService<QuestionnaireResult>
    {
        /// <summary>
        /// questionnaire result repository
        /// </summary>
        private readonly IRepository<QuestionnaireResult> _questionnaireResultRepository;

        /// <summary>
        /// Connect to repository
        /// </summary>
        /// <param name="questionnaireResultRepository"></param>
        public QuestionnaireResultService(IRepository<QuestionnaireResult> questionnaireResultRepository)
        {
            _questionnaireResultRepository = questionnaireResultRepository;
        }

        /// <summary>
        /// Create new result
        /// </summary>
        /// <param name="result"></param>
        /// <returns>result</returns>
        public async Task<QuestionnaireResult> CreateAsync(QuestionnaireResult result)
        {
            Regex nameValidation = new Regex(@"^[A-Z]{1}[a-z]+$");
            if (!nameValidation.IsMatch(result.FirstName) ||
                !nameValidation.IsMatch(result.LastName))
                throw new ArgumentException();
            return await _questionnaireResultRepository.CreateAsync(result);
        }

        /// <summary>
        /// Get all results
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<QuestionnaireResult>> GetAllAsync()
        {
            return await _questionnaireResultRepository.GetAllAsync();
        }

        /// <summary>
        /// Get result by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<QuestionnaireResult> GetByIdAsync(int id)
        {
            return await _questionnaireResultRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Update result
        /// </summary>
        /// <param name="result">new result</param>
        /// <returns>update result</returns>
        public async Task<bool> UpdateAsync(QuestionnaireResult result)
        {
            return await _questionnaireResultRepository.UpdateAsync(result);
        }

        /// <summary>
        /// Delete result by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>delete result</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            return await _questionnaireResultRepository.DeleteAsync(id);
        }
    }
}