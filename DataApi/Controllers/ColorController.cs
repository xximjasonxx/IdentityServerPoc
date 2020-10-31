using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DataApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private static readonly string[] Colors = new[]
        {
            "Green", "Blue", "Orange", "Yellow", "Red", "Black", "White", "Brown", "Pink", "Purple", "Gray"
        };

        [HttpGet]
        public IActionResult Get()
        {
            var rng = new Random();
            return Ok(new
            {
                User = this.User.Identity.Name,
                Colors = new List<string>
                {
                    Colors.ElementAt(rng.Next(0, Colors.Length - 1)),
                    Colors.ElementAt(rng.Next(0, Colors.Length - 1)),
                    Colors.ElementAt(rng.Next(0, Colors.Length - 1)),
                    Colors.ElementAt(rng.Next(0, Colors.Length - 1)),
                    Colors.ElementAt(rng.Next(0, Colors.Length - 1))
                }
            });
        }
    }
}
