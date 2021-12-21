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
        /// Open main page with choosen tags
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Index(string tags)
        {
            var tagsArr = GetTags(tags);
            var searchedArticles = await ((ArticleService)_articlesService).GetByTagsAsync(tagsArr);
            return View("Index", searchedArticles);
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