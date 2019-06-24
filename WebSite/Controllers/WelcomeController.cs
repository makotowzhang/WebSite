using System.Web.Mvc;

namespace WebSite.Controllers
{
    public class WelcomeController : BaseController
    {
        // GET: Welcome
        public ActionResult Index()
        {
            return View();
        }

    }
}