using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApp.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("https://localhost:44372/logout");
        }
    }
}
