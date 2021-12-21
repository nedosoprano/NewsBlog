using NewsBlogDAL.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace NewsBlogDAL.Repositories
{
    /// <summary>
    /// Interaction to database
    /// </summary>
    public class QuestionnaireResultRepository : IRepository<QuestionnaireResult>
    {
        /// <summary>
        /// database context
        /// </summary>
        private readonly NewsBlogContext _newsBlogContext;

        /// <summary>
        /// Connect to context
        /// </summary>
        /// <param name="newsBlogContext"></param>
        public QuestionnaireResultRepository(NewsBlogContext newsBlogContext)
        {
            _newsBlogContext = newsBlogContext;
        }

        /// <summary>
        /// Create questionnaire result
        /// </summary>
        /// <param name="questionnaireResult"></param>
        /// <returns>questionnaire result</returns>
        public async Task<QuestionnaireResult> CreateAsync(QuestionnaireResult questionnaireResult)
        {
            _newsBlogContext.QuestionnaireResults.Add(questionnaireResult);
            await _newsBlogContext.SaveChangesAsync();
            return questionnaireResult;
        }

        /// <summary>
        /// Delete questionnaire result by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>delete result</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var result = _newsBlogContext.QuestionnaireResults.Attach(new QuestionnaireResult { Id = id });
            bool isNull = result == null;
            if (!isNull)
            {
                _newsBlogContext.Entry(result).State = EntityState.Deleted;
                await _newsBlogContext.SaveChangesAsync();
            }
            return !isNull;
        }

        /// <summary>
        /// Get all questionnaire results
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<QuestionnaireResult>> GetAllAsync()
        {
            return await _newsBlogContext.QuestionnaireResults.ToListAsync();
        }

        /// <summary>
        /// Get questionnaire result by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<QuestionnaireResult> GetByIdAsync(int id)
        {
            return await _newsBlogContext.QuestionnaireResults.FindAsync(id);
        }

        /// <summary>
        /// Update questionnaire result
        /// </summary>
        /// <param name="questionnaireResult">new questionnaire result</param>
        /// <returns>update result</returns>
        public async Task<bool> UpdateAsync(QuestionnaireResult questionnaireResult)
        {
            var result = _newsBlogContext.QuestionnaireResults.Attach(questionnaireResult);
            var isNull = result == null;
            if (!isNull)
            {
                _newsBlogContext.Entry(result).State = EntityState.Modified;
                await _newsBlogContext.SaveChangesAsync();
            }
            return !isNull;
        }
    }
}