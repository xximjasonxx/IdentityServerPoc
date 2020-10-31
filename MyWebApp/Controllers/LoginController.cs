using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            var redirectUri = WebUtility.UrlEncode("https://localhost:44370/Login/Callback");
            var url = $"https://localhost:44372/connect/authorize?client_id=client&scope=openid+profile+read&response_type={WebUtility.UrlEncode("id_token token")}&redirect_uri={redirectUri}&nonce=xyz&state=abc&response_mode=form_post";

            return Redirect(url);
        }

        public IActionResult Callback(string id_token, string access_token)
        {
            ViewData["id_token"] = id_token;
            ViewData["access_token"] = access_token;
            return View();
        }
    }
}
