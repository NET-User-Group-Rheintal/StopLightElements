namespace StopLightElements.Endpoints.HelloWorld;

public static class HelloWorldEndpointExtensions
{
    public static IEndpointRouteBuilder MapHelloWorldEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapHelloWorld();
        return app;
    }
}
