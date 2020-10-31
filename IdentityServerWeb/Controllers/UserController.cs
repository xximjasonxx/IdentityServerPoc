using System.Linq;
using System.Threading.Tasks;
using IdentityServerWeb.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityServerWeb.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IdentityContext _context;

        public UserController(UserManager<IdentityUser> userManager, IdentityContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserRequest createRequest)
        {
            var user = await _userManager.CreateAsync(new IdentityUser
            {
                UserName = createRequest.Username,
                EmailConfirmed = true,
                Email = "test@aol.com"
            }, "Password01!");

            return Created(string.Empty, user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpPost("assign")]
        public async Task<IActionResult> AssignUser([FromBody]AssignUseToRoleRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            var result = await _userManager.AddToRoleAsync(user, request.RoleName);

            return Created(string.Empty, result);
        }
    }

    public class CreateUserRequest
    {
        public string Username { get; set; }
    }

    public class AssignUseToRoleRequest
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
    }
}