using GRNCars.BL.Abstract;
using GRNCars.Entities;
using GRNCars.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GRNCars.WebUI.Controllers
{
    public class HomeController : Controller
    {

        private readonly IService<Slider> _service;
        private readonly ICarService _serviceVehicle;

        public HomeController(IService<Slider> service, ICarService serviceVehicle)
        {
            _service = service;
            _serviceVehicle = serviceVehicle;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var model = new HomePageViewModel()
            {
                Sliders = await _service.GetAllAsync(),
                Vehicles = await _serviceVehicle.GetCustomCarList(a => a.Anasayfa)
            };


            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Route("AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
