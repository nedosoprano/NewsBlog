using NewsBlogDAL.Models;
using NewsBlogBLL.Services;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace NewsBlog.Controllers
{
    /// <summary>
    /// Controller for main page
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// article service
        /// </summary>
        private static IService<Article> _articlesService;

        /// <summary>
        /// Connect to article service
        /// </summary>
        /// <param name="articlesService"></param>
        public HomeController(IService<Article> articlesService)
        {
            _articlesService = articlesService;
        }

        /// <summary>
        /// Open main page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(await _articlesService.GetAllAsync());
        }

        /// <summary>
        /// Open main page with sorted articles or choosen tags
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Index(string sortMethod, string tags)
        {
            if (tags != null) return View(await GetArticlesByTags(tags));
            return View(await SortArticles(sortMethod));
        }

        /// <summary>
        /// Open article full text
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Details(int id)
        {
            return View(await _articlesService.GetByIdAsync(id));
        }

        /// <summary>
        /// Return articles with appropriate tag
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        private async Task<IEnumerable<Article>> GetArticlesByTags(string tags)
        {
            string[] tagsArr = GetTags(tags);
            var chosenArticles = await ((ArticleService)_articlesService).GetByTagsAsync(tagsArr);
            return chosenArticles;
        }

        /// <summary>
        /// Return list of articles which sorted in the chosen order
        /// </summary>
        /// <param name="sortMethod"></param>
        /// <returns></returns>
        private async Task<IEnumerable<Article>> SortArticles(string sortMethod)
        {
            var articlesForSorting = await _articlesService.GetAllAsync();
            switch (sortMethod)
            {
                case "Title": return articlesForSorting.OrderBy(a => a.Title).Reverse();
                default: return articlesForSorting.OrderBy(a => a.CreationDate);
            }
        }

        /// <summary>
        /// Separate tags
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        private string[] GetTags(string tags)
        {
            Regex tagPattern = new Regex(@"\w+");
            return tagPattern.Matches(tags).Cast<Match>()
                                           .Select(m => m.Value)
                                           .ToArray();
        }
    }
}