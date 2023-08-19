using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WepApp.Data;
using WepApp.Models;

namespace WepApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(
            SignInManager<AppUser> signInManager, 
            UserManager<AppUser> userManager, 
            ILogger<AccountController> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        public IActionResult Index() => View();

        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterUserModel model)
        {
            if (ModelState.IsValid)
            {
                var newUser = new AppUser
                {
                    UserName = model.Username,
                    Email = model.Email,
                    Fullname = model.Fullname,
                };
                var result= await _userManager.CreateAsync(newUser, model.Password);
                if (result.Succeeded)
                {
                   return RedirectToAction("Index");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(model);
        }

    }
}
