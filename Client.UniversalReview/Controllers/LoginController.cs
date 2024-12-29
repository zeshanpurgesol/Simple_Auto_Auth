using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Client.UniversalReview.Controllers
{
    [Route("api/v1/web/accounts/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult ajax(FormCollection fc)
        {
            var res = Request;
            return Ok("hghg");
        }
        [HttpPost]
        public IActionResult ajax()
        {
            var gg = Request;
            var res = JsonSerializer.Serialize(gg);
            return Ok("hghg");
        }
    }
}
