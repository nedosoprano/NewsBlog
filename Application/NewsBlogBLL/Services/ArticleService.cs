using NewsBlogDAL.Enums;
using NewsBlogDAL.Models;
using NewsBlogDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlogBLL.Services
{
    /// <summary>
    /// Interaction with articles repository
    /// </summary>
    public class ArticleService : IService<Article>
    {
        /// <summary>
        /// article repository
        /// </summary>
        private readonly IRepository<Article> _articleRepository;

        /// <summary>
        /// Connect to repository
        /// </summary>
        /// <param name="articleRepository"></param>
        public ArticleService(IRepository<Article> articleRepository)
        {
            _articleRepository = articleRepository;
        }

        /// <summary>
        /// Create article
        /// </summary>
        /// <param name="article"></param>
        /// <returns>article</returns>
        public async Task<Article> CreateAsync(Article article)
        {
            if (article == null ||
                article.Text == null ||
                article.Title == null)
                throw new ArgumentException();
            return await _articleRepository.CreateAsync(article);
        }

        /// <summary>
        /// Get all articles
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            return await _articleRepository.GetAllAsync();
        }

        /// <summary>
        /// Get article by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Article> GetByIdAsync(int id)
        {
            return await _articleRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Get articles by tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Article>> GetByTagAsync(string tag)
        {
            var articles =  await _articleRepository.GetAllAsync();
            return articles.Where(a => a.Tag.ToString() == tag || a.Text.Contains(tag));
        }

        /// <summary>
        /// Get articles by tags
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Article>> GetByTagsAsync(string[] tags)
        {
            var searchedArticles = new List<Article>();
            foreach (var tag in tags)
                searchedArticles.AddRange(await GetByTagAsync(tag));
            return searchedArticles.Distinct();
        }

        /// <summary>
        /// Update article
        /// </summary>
        /// <param name="article">new article</param>
        /// <returns>update result</returns>
        public async Task<bool> UpdateAsync(Article article)
        {
            if (article == null ||
                article.Text == null ||
                article.Title == null)
                throw new ArgumentException();
            return await _articleRepository.UpdateAsync(article);
        }

        /// <summary>
        /// Delete article by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>delete result</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            return await _articleRepository.DeleteAsync(id);
        }
    }
}