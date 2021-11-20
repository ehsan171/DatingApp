using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    public class ResourceController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}