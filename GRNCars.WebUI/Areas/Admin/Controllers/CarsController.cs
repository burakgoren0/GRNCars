using GRNCars.BL.Abstract;
using GRNCars.Entities;
using GRNCars.WebUI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GRNCars.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class CarsController : Controller
    {
        private readonly ICarService _service;
        private readonly IService<Brand> _serviceBrand;

        public CarsController(ICarService service, IService<Brand> serviceBrand)
        {
            _service = service;
            _serviceBrand = serviceBrand;
        }

        // GET: CarsController
        public async Task<IActionResult> IndexAsync()
        {
            var model = await _service.GetCustomCarList();
            return View(model);
        }

        // GET: CarsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarsController/Create
        public async Task<ActionResult> CreateAsync()
        {
            ViewBag.BrandId = new SelectList(await _serviceBrand.GetAllAsync(), "Id", "Name");
            return View();
        }

        // POST: CarsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Vehicle vehicle, IFormFile? Image, IFormFile? Image2, IFormFile? Image3)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    vehicle.Image = await FileHelper.FileLoaderAsync(Image, "/Img/Cars/");
                    vehicle.Image2 = await FileHelper.FileLoaderAsync(Image2, "/Img/Cars/");
                    vehicle.Image3 = await FileHelper.FileLoaderAsync(Image3, "/Img/Cars/");
                    await _service.AddAsync(vehicle);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.BrandId = new SelectList(await _serviceBrand.GetAllAsync(), "Id", "Name");
            return View(vehicle);
        }

        // GET: CarsController/Edit/5
        public async Task<IActionResult> EditAsync(int id)
        {
            ViewBag.BrandId = new SelectList(await _serviceBrand.GetAllAsync(), "Id", "Name");
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: CarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Vehicle vehicle, IFormFile? Image, IFormFile? Image2, IFormFile? Image3)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Image is not null)
                    {
                        vehicle.Image = await FileHelper.FileLoaderAsync(Image, "/Img/Cars/");
                    }
                    if (Image2 is not null)
                    {
                        vehicle.Image2 = await FileHelper.FileLoaderAsync(Image2, "/Img/Cars/");
                    }
                    if (Image3 is not null)
                    {
                        vehicle.Image3 = await FileHelper.FileLoaderAsync(Image3, "/Img/Cars/");
                    }

                    _service.Update(vehicle);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.BrandId = new SelectList(await _serviceBrand.GetAllAsync(), "Id", "Name");
            return View(vehicle);
        }

        // GET: CarsController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: CarsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, Vehicle vehicle)
        {
            try
            {
                _service.Delete(vehicle);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
