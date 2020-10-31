using System;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Events;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using IdentityServerWeb.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServerWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IIdentityServerInteractionService _interactionService;


        public LoginController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager,
            IIdentityServerInteractionService interactionService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _interactionService = interactionService;
        }

        public IActionResult Index(string returnUrl)
        {
            if (!Uri.TryCreate(returnUrl, UriKind.RelativeOrAbsolute, out Uri returnUri))
                return RedirectToAction(nameof(Fail));

            return View("Login", new LoginRequestModel(returnUrl));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromForm]LoginRequestModel loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", loginRequest);
            }

            var context = await _interactionService.GetAuthorizationContextAsync(loginRequest.ReturnUrl);
            if (context != null)
            {
                var result = await _signInManager.PasswordSignInAsync(loginRequest.Username, loginRequest.Password,
                    isPersistent: true,
                    lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return Redirect(loginRequest.ReturnUrl);
                }
            }

            return RedirectToAction(nameof(Fail));
        }

        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Fail()
        {
            return View();
        }
    }
}   