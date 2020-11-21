using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace GuppyDive.Commands
{
    public class Greeting
    {
        public string Message { get; set; }
    }

    public interface IGreeterCommand
    {
        Task<Greeting> Greet(
                string name,
                CancellationToken cancellationToken = default);

        Task<Greeting> GreetFrom(
                string name,
                string from,
                CancellationToken cancellationToken = default);
    }

    public class GreeterCommand : IGreeterCommand
    {
        private readonly ILogger<GreeterCommand> logger;

        public GreeterCommand(ILogger<GreeterCommand> logger)
        {
            this.logger = logger;
        }

        public Task<Greeting> Greet(
                string name,
                CancellationToken cancellationToken = default)
        {
            logger.LogInformation("Replying with greeting.");
            var greeting = new Greeting
            {
                Message = "Hello " + name,
            };
            return Task.FromResult(greeting);
        }

        public Task<Greeting> GreetFrom(
                string name,
                string from,
                CancellationToken cancellationToken = default)
        {
            logger.LogInformation(
                    $"Sending hello to {name} from {from}");
            var greeting = new Greeting
            {
                Message = $"Hello {name} from {from}",
            };
            return Task.FromResult(greeting);
        }
    }
}
