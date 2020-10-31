using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataApi.Controllers
{
    [Authorize("IsWriter")]
    [ApiController]
    [Route("data")]
    public class SaveController : ControllerBase
    {
        public readonly static IDictionary<string, string> HashTable = new Dictionary<string, string>();

        [HttpPost]
        public IActionResult WriteColor([FromBody]WriteKeyValueRequest request)
        {
            HashTable.Add(request.Key, request.Value);

            return Created(string.Empty, HashTable);
        }
    }

    public class WriteKeyValueRequest
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
