using Microsoft.AspNetCore.Mvc;

namespace StopLightElements.Endpoints.HelloWorld;

public static class HelloWorldEndpoint
{
    public static IEndpointRouteBuilder MapHelloWorld(this IEndpointRouteBuilder app)
    {
        app.MapGet(ApiEndpoints.Hello.MinimalApi, ([FromQuery] string name) => $"Hello {name}")
        .WithName("Hello World from Minimal Api")
        .WithDisplayName("Hello World Minimal Api")
        .WithTags("HelloWorld")
        .WithDescription("Hello World from Minimal API Endpoint")
        .Produces<string>(StatusCodes.Status200OK)
        .WithOpenApi();

        return app;
    }
}
