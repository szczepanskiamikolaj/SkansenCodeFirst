using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkansenCodeFirst.Model.Identity;
using System.Threading.Tasks;

namespace SkansenCodeFirst.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private IMapper _mapper;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registermodel)
        {
            if (ModelState.IsValid)
            {
                User user = new Model.Identity.User
                {
                    UserName = registermodel.Email,
                    Email =
                registermodel.Email
                };
                IdentityResult result = await _userManager.CreateAsync(user, registermodel.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToPage("./Index");
                }
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, err.Description);
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel
        loginViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = new Model.Identity.User
                {
                    Email =
                loginViewModel.Email,
                    UserName = loginViewModel.Email
                };
                Microsoft.AspNetCore.Identity.SignInResult
                identityResult = await
                _signInManager.PasswordSignInAsync(user.Email,
                loginViewModel.Password, false, false);
                if (identityResult.Succeeded)
                {
                    return RedirectToPage("./Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty,
                    "Niepoprawny login lub hasło.");
                }
            }
            return View();
        }
        [HttpGet]
        [Authorize]
        public IActionResult Welcome()
        {
            return View();
        }
    }
}

