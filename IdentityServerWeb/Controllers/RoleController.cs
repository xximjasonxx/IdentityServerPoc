using System.Threading.Tasks;
using IdentityServerWeb.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityServerWeb.Controllers
{
    [Route("api/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IdentityContext _context;

        public RoleController(RoleManager<IdentityRole> roleManager, IdentityContext context)
        {
            _roleManager = roleManager;
            _context = context;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateRole([FromBody]CreateRoleRequest request)
        {
            var role = await _roleManager.CreateAsync(new IdentityRole
            {
                Name = request.RoleName,
                NormalizedName = request.RoleName
            });

            return Created(string.Empty, role);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Roles.ToListAsync());
        }
    }

    public class CreateRoleRequest
    {
        public string RoleName { get; set; }
    }
}
