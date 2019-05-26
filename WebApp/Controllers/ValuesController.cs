using Microsoft.AspNetCore.Mvc;
using WebApp.Configurations;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ValuesController : ControllerBase
    {
        private readonly SpaConfig _spaConfig;

        public ValuesController(SpaConfig spaConfig)
        {
            _spaConfig = spaConfig;
        }

        [HttpGet]
        public JsonResult Name()
        {
            return new JsonResult(_spaConfig);
        }
    }
}