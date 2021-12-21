using NewsBlogDAL.Models;
using NewsBlogBLL.Services;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using System.Linq;

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
        /// Open main page with sorted articles
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Index(string sortMethod)
        {
            var articlesForSorting = await _articlesService.GetAllAsync();
            switch (sortMethod)
            {
                case "Title": return View(articlesForSorting.OrderBy(a => a.Title).Reverse());
                default: return View(articlesForSorting.OrderBy(a => a.CreationDate));
            }
        }

        /// <summary>
        /// Open main page with choosen tags
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> FilteredArticles(string tags)
        {
            var tagsArr = GetTags(tags);
            var searchedArticles = await ((ArticleService)_articlesService).GetByTagsAsync(tagsArr);
            return View(searchedArticles);
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