using Microsoft.OpenApi.Models;
using StopLightElements.Endpoints;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Add Swagger Doc and XML Comments
builder.Services.AddSwaggerGen(options =>
{
    // Describe your API
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "1.0.0",
        Title = "Hello World Api - OpenAPI 3.0",
        Description = "A description for the Hello World Api",
        Contact = new OpenApiContact
        {
            Email = "mail@rheintal-dotnet.com",
        },
    });

    // Generates XML with Reflection
    options.IncludeXmlComments($"{AppDomain.CurrentDomain.BaseDirectory}{Path.DirectorySeparatorChar}{Assembly.GetExecutingAssembly().GetName().Name}.xml");
});

var app = builder.Build();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseStaticFiles(); // Required for Elements HTML and Swaggerfiles
app.MapControllers();
app.MapApiEndpoints();

// Routing for index page
app.MapGet("/", context =>
{
    context.Response.Redirect("/index.html");
    return Task.CompletedTask;
});

app.Run();
