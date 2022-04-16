using NewsBlogDAL.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace NewsBlogDAL.Repositories
{
    /// <summary>
    /// Interaction with articles
    /// </summary>
    public class ArticleRepository : IRepository<Article>
    {
        /// <summary>
        /// Database context
        /// </summary>
        private readonly NewsBlogContext _newsBlogContext;

        /// <summary>
        /// Connection to database context
        /// </summary>
        /// <param name="newsBlogContext"></param>
        public ArticleRepository(NewsBlogContext newsBlogContext)
        {
            _newsBlogContext = newsBlogContext;
        }

        /// <summary>
        /// Create new article
        /// </summary>
        /// <param name="article"></param>
        /// <returns>article</returns>
        public async Task<Article> CreateAsync(Article article)
        {
            _newsBlogContext.Articles.Add(article);
            await _newsBlogContext.SaveChangesAsync();
            return article;
        }

        /// <summary>
        /// Delete article by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>delete result</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var article = _newsBlogContext.Articles.Attach(new Article { Id = id });
            bool isNull = article == null;
            if (!isNull)
            {
                _newsBlogContext.Entry(article).State = EntityState.Deleted;
                await _newsBlogContext.SaveChangesAsync();
            }
            return !isNull;
        }

        /// <summary>
        /// Get all articles by id
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            return await _newsBlogContext.Articles.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Get artcle by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Article> GetByIdAsync(int id)
        {
            return await _newsBlogContext.Articles.FindAsync(id);
        }

        /// <summary>
        /// Update article
        /// </summary>
        /// <param name="article"></param>
        /// <returns>update result</returns>
        public async Task<bool> UpdateAsync(Article article)
        {
            var newArticle = _newsBlogContext.Articles.Attach(article);
            _newsBlogContext.Entry(article).State = EntityState.Modified;
            await _newsBlogContext.SaveChangesAsync();
            return newArticle != null;
        }
    }
}