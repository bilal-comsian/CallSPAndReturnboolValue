using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApp.DatabaseInfo;

namespace TestApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ForSPController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        public ForSPController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        public bool Get()
        {
            int id = 10;
            ForSPCalls forSPCalls = new ForSPCalls();
            return forSPCalls.GetvalueFromSP(id);
        }

       
    }
}
