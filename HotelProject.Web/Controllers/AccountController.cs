using AutoMapper;
using HotelProject.Models.DTOs;
using HotelProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace HotelProject.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(UserRegistrationDTO userModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }

            var user = _mapper.Map<ApplicationUser>(userModel);
            var result = await _userManager.CreateAsync(user, userModel.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.TryAddModelError(error.Code, error.Description);

                return View(userModel);
            }

            await _userManager.AddToRoleAsync(user, "Customer");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDTO userModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }

            var user = await _userManager.FindByEmailAsync(userModel.Email);

            if (user != null)
            {
                await _userManager.CheckPasswordAsync(user, userModel.Password);

                ClaimsIdentity identity = new(IdentityConstants.ApplicationScheme);
                var roles = await _userManager.GetRolesAsync(user);


                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName!));

                foreach (var role in roles)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, role));
                }

                await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, new ClaimsPrincipal(identity));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid UserName or Password");
                return View();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
