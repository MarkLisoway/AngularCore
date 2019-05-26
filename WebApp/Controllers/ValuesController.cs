using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApp.Configurations;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ValuesController : ControllerBase
    {
        private readonly IOptions<SpaConfig> _spaConfig;

        public ValuesController(IOptions<SpaConfig> spaConfig)
        {
            _spaConfig = spaConfig;
        }

        [HttpGet]
        public JsonResult Name()
        {
            return new JsonResult(_spaConfig.Value);
        }
    }
}