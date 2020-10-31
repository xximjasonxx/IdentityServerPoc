using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServerWeb.Controllers
{
    public class LogoutController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public LogoutController(SignInManager<IdentityUser> signinManager)
        {
            _signInManager = signinManager;
        }

        public async Task<IActionResult> Index()
        {
            await _signInManager.SignOutAsync();
            await HttpContext.SignOutAsync(IdentityServerConstants.DefaultCookieAuthenticationScheme);
            return Redirect("https://localhost:44370/home");

        }
    }
}
