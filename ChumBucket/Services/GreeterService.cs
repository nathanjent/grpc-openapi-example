using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Greet;

namespace ChumBucket
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> logger;

        public GreeterService(ILogger<GreeterService> logger)
        {
            this.logger = logger;
        }

        public override Task<HelloReply> SayHello(
            HelloRequest request,
            ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        public override Task<HelloReply> SayHelloFrom(
            HelloRequestFrom request,
            ServerCallContext context)
        {
            logger.LogInformation(
                    $"Sending hello to {request.Name} from {request.From}");
            return Task.FromResult(
                    new HelloReply
                    {
                        Message = $"Hello {request.Name} from {request.From}"
                    });
        }
    }
}
