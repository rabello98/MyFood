using Microsoft.AspNetCore.Mvc;

namespace MyFood.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
