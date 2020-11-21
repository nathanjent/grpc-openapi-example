using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Greet;
using GuppyDive.Commands;

namespace GuppyDive
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly IGreeterCommand greeter;
        private readonly ILogger<GreeterService> logger;

        public GreeterService(
                IGreeterCommand greeter,
                ILogger<GreeterService> logger)
        {
            this.greeter = greeter;
            this.logger = logger;
        }

        public override async Task<HelloReply> SayHello(
            HelloRequest request,
            ServerCallContext context)
        {
            var greeting = await greeter.Greet(request.Name);
            return new HelloReply
            {
                Message = greeting.Message,
            };
        }

        public override async Task<HelloReply> SayHelloFrom(
            HelloRequestFrom request,
            ServerCallContext context)
        {
            logger.LogTrace(
                    $"Received request to send greeting to {request.Name} from {request.From}");
            var greeting = await greeter.GreetFrom(request.Name, request.From);
            return new HelloReply
            {
                Message = greeting.Message,
            };
        }
    }
}
