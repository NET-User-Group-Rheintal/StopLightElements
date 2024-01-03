using StopLightElements.Endpoints.HelloWorld;

namespace StopLightElements.Endpoints;

public static class EndpointsExtensions
{
    public static IEndpointRouteBuilder MapApiEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapHelloWorldEndpoints();
        return app;
    }
}

