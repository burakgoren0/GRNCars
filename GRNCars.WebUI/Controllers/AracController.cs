using GRNCars.BL.Abstract;
using GRNCars.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GRNCars.WebUI.Controllers
{
    public class AracController : Controller
    {
        private readonly ICarService _serviceVehicle;
        private readonly IService<Customer> _serviceCustomer;

        public AracController(ICarService serviceVehicle, IService<Customer> serviceCustomer)
        {
            _serviceVehicle = serviceVehicle;
            _serviceCustomer = serviceCustomer;
        }

        public async Task<IActionResult> IndexAsync(int? id)
        {
            var model = await _serviceVehicle.GetCustomCar(id.Value);
            return View(model);
        }
        [Route("tum-araclarimiz")]
        public async Task<IActionResult> List()
        {
            var model = await _serviceVehicle.GetCustomCarList(p => p.IsSale);
            return View(model);
        }
        public async Task<IActionResult> Ara(string q)
        {
            var model = await _serviceVehicle.GetCustomCarList(p => p.IsSale && p.Brand.Name.Contains(q) || p.CaseType.Contains(q) || p.Model.Contains(q));
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CustomerRegistration(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _serviceCustomer.AddAsync(customer);
                    await _serviceCustomer.SaveAsync();
                    return Redirect("/Arac/Index/" + customer.VehicleId);
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View();
        }

    }
}
