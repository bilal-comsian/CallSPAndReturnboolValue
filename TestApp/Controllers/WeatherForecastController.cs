using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TestApp.DatabaseInfo;

namespace TestApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetSPCallController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<GetSPCallController> _logger;
        public IConfiguration configuration { get; set; }
        public GetSPCallController(ILogger<GetSPCallController> logger, IConfiguration config)
        {
            _logger = logger;
            configuration= config;
        }

        [HttpGet(Name = "GetvalueFromSP")]
        public bool Get([Required] int id)
        {
            ForSPCalls forSPCalls = new ForSPCalls();
            return forSPCalls.GetvalueFromSP(id);
        }
    }
}