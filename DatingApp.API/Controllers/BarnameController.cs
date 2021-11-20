using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    public class BarnameController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}