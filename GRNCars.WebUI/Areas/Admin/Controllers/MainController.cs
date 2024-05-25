using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GRNCars.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
