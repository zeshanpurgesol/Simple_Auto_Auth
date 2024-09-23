using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Simple_Auto_Auth.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public ActionResult GetAuthData()
        {
            return Ok("Successfull get AuthData");
        }
        [HttpGet]
        public ActionResult GetSimpleData()
        {
            return Ok("Successfull get SimpleData");
        }
    }
}
