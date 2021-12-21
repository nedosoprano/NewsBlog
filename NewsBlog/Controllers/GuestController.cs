using NewsBlogDAL.Models;
using NewsBlogBLL.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NewsBlog.Controllers
{
    /// <summary>
    /// Controller for feedback page
    /// </summary>
    public class GuestController : Controller
    {
        /// <summary>
        /// feedback service
        /// </summary>
        private static IService<Feedback> _feedbackServices;

        /// <summary>
        /// Connect to feedback service
        /// </summary>
        /// <param name="feedbackServices"></param>
        public GuestController(IService<Feedback> feedbackServices)
        {
            _feedbackServices = feedbackServices;
        }

        /// <summary>
        /// Open feedbacks page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Guest()
        {
            await _feedbackServices.GetAllAsync();
            return View(await _feedbackServices.GetAllAsync());
        }

        /// <summary>
        /// Feedback handling page
        /// </summary>
        /// <param name="feedback">new feedback</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Guest(Feedback feedback)
        {
            if (!ModelState.IsValid) return Redirect("Guest");
            try
            {
                await _feedbackServices.CreateAsync(feedback);
            }
            catch { return Redirect("Guest"); }
            return Redirect("Guest");
        }
    }
}