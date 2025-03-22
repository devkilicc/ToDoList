using Microsoft.AspNetCore.Mvc;

namespace ToDoListApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
