using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServerWeb.Controllers
{
    [ApiController]
    [Route("api/Client")]
    public class ClientController : ControllerBase
    {


        /*[HttpPost]
        public async Task<IActionResult> CreateClient([FromBody]ClientCreateRequest request)
        {
            
        }*/
    }

    public class ClientCreateRequest
    {
        public string ClientId { get; set; }
    }
}