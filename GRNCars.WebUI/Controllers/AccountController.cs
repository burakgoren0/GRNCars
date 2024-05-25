using GRNCars.BL.Abstract;
using GRNCars.Entities;
using GRNCars.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GRNCars.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _service;
        private readonly IService<Role> _serviceRole;

        public AccountController(IUserService service, IService<Role> serviceRole)
        {
            _service = service;
            _serviceRole = serviceRole;
        }
        [Authorize(Policy = "CustomerPolicy")]
        public IActionResult Index()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var uguid = User.FindFirst(ClaimTypes.UserData)?.Value;
            if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(uguid))
            {
                var user = _service.Get(k => k.Email == email && k.UserGuid.ToString() == uguid);
                if (user != null)
                {
                    return View(user);
                }
            }
            return NotFound();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var role = await _serviceRole.GetAsync(r => r.Name == "Customer");
                    if (role == null)
                    {
                        ModelState.AddModelError("", "Kayıt Başarısız!");
                        return View();
                    }
                    user.RoleId = role.Id;
                    user.IsActive = true;
                    await _service.AddAsync(user);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(CustomerLoginViewModel customerViewModel)
        {
            try
            {
                var account = await _service.GetAsync(k => k.Email == customerViewModel.Email && k.Password == customerViewModel.Password && k.IsActive == true);
                if (account == null)
                {
                    ModelState.AddModelError("", "Giriş Başarısız!");
                }
                else
                {
                    var role = _serviceRole.Get(r => r.Id == account.RoleId);
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, account.Name),
                        new Claim(ClaimTypes.Email, account.Email),
                        new Claim(ClaimTypes.UserData, account.UserGuid.ToString())

                    };
                    if (role is not null)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.Name));
                    }
                    var userIdentity = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);
                    if (role.Name == "Admin")
                    {
                        return Redirect("/Admin");
                    }
                    return Redirect("/Account");


                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View();
        }
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }



    }
}
