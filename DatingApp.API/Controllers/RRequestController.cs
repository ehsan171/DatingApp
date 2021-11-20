using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    public class RRequestController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}