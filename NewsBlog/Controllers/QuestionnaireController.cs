using NewsBlogDAL.Models;
using NewsBlogBLL.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NewsBlog.Controllers
{
    /// <summary>
    /// Controller for questionneire pages
    /// </summary>
    public class QuestionnaireController : Controller
    {
        /// <summary>
        /// questionneire service
        /// </summary>
        private static IService<QuestionnaireResult> _questionnaireResultServices;

        /// <summary>
        /// Connect to questionneire page
        /// </summary>
        /// <param name="questionnaireResultService"></param>
        public QuestionnaireController(IService<QuestionnaireResult> questionnaireResultService)
        {
            _questionnaireResultServices = questionnaireResultService;
        }

        /// <summary>
        /// Page for fill questionneire
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Questionnaire()
        {
            return View();
        }

        /// <summary>
        /// Questionneire result page
        /// </summary>
        /// <param name="result"></param>
        /// <returns>questionneire result page</returns>
        [HttpPost]
        public async Task<ActionResult> Questionnaire(QuestionnaireResult result)
        {
            if (!ModelState.IsValid) return Redirect("Questionnaire");
            try
            {
                await _questionnaireResultServices.CreateAsync(result);
            }
            catch { return Redirect("Questionnaire"); }

            ViewBag.QuestionnaireResult = result;
            return View("QuestionnaireSent");
        }
    }
}