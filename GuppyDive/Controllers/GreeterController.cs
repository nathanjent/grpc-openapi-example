using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Greet;
using GuppyDive.Commands;
using System.Threading.Tasks;

namespace GuppyDive.Controllers
{
    [ApiController]
    [Route("V1/[controller]")]
    public class GreeterController : ControllerBase
    {
        private readonly IGreeterCommand greeter;
        private readonly ILogger<GreeterController> logger;

        public GreeterController(
                IGreeterCommand greeter,
                ILogger<GreeterController> logger)
        {
            this.greeter = greeter;
            this.logger = logger;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Greeting>> SayHello(
            string name)
        {
            var greeting = await greeter.Greet(name);
            return Ok(greeting);
        }

        [HttpPost]
        public async Task<ActionResult<Greeting>> SayHelloFrom(
            HelloRequestFrom request)
        {
            var greeting = await greeter.GreetFrom(
                    request.Name,
                    request.From);
            return Ok(greeting);
        }
    }
}
