# gRPC with OpenAPI Example

This is a project to explore running a .Net application
that can communicate using both gRPC and REST interfaces.
The main use case is to bridge the gap between legacy
applications that can only feasibly add support for REST API
communications defined by OpenAPI.

## Experimental Work from AspLabs

An [experimental project](jhttps://github.com/aspnet/AspLabs/tree/master/src/GrpcHttpApi/sample)
exists that combines the Swagger OpenAPI generator with
the gRPC API generated from protocol buffers (`.proto` files).
The ChumBucket project shows an example using this setup.
The main limitation with this is the blocking serialization
using Protobuf JSON. Until this limitation is resolved we
can try some alternative ideas.

## Share Service and Controller

With this we can define gRPC services using Protobuf and
have these wrap the common logic that could then be shared
by manually defined Web API controllers. The GuppyDive
project shows and example of this.
