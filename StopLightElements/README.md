# Stoplight Elements

[Stoplight Elements](https://stoplight.io/open-source/elements) is an Alternative to Swagger.

This documentation explains how to integratie into a ASP.NET Core Web Api

## Links
* [Github](https://github.com/stoplightio/elements)
* [Docs](https://docs.stoplight.io/docs/elements)
* [Demo](https://elements-demo.stoplight.io)

# Install Stoplight Elements in an ASP.NET Core Web Api
## Requirements
* [Swagger CLI Tools](https://www.nuget.org/packages/Swashbuckle.AspNetCore.Cli) (generates OpenApi/Swagger Files for Stoplight)
`dotnet tool install --global Swashbuckle.AspNetCore.Cli`

## Install
1. Create folder _**wwwroot**_ in API project
2. Create _**index.html**_ file in wwwroot
```
<!doctype html>
<html lang="en">
  <head>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
	<title>Elements in HTML</title>
	<!-- Embed elements Elements via Web Component -->
	<script src="https://unpkg.com/@stoplight/elements/web-components.min.js"></script>
	<link rel="stylesheet" href="https://unpkg.com/@stoplight/elements/styles.min.css">
  </head>
  <body>

	<elements-api
	  apidescriptionurl="swagger.json"
	  router="hash"
	  layout="sidebar"
	/>

  </body>
</html>
```
3. Edit project file
* Add GenerateDocumentationFile to Project `<GenerateDocumentationFile>True</GenerateDocumentationFile>`
```
<PropertyGroup>
 <TargetFramework>net8.0</TargetFramework>
 <Nullable>enable</Nullable>
 <ImplicitUsings>enable</ImplicitUsings>
 <InvariantGlobalization>true</InvariantGlobalization>
 <GenerateDocumentationFile>True</GenerateDocumentationFile>
 <NoWarn>$(NoWarn);1591</NoWarn> 
</PropertyGroup>
```
* Update Swashbuckle.AspNetCore to 6.5
```<PackageReference Include="Swashbuckle.AspNetCore" Version="6.5.0" />```
* Add build actions to project to create swagger files for Elements

```
<Target Name="OpenAPI" AfterTargets="Build">
	<Exec Command="swagger tofile --output ./wwwroot/swagger.yaml --yaml $(OutputPath)$(AssemblyName).dll v1" WorkingDirectory="$(ProjectDir)" />
	<Exec Command="swagger tofile --output ./wwwroot/swagger.json $(OutputPath)$(AssemblyName).dll v1" WorkingDirectory="$(ProjectDir)" />
</Target>
```


4. Program.cs
* Add static files
```app.UseStaticFiles();```
* Add Swagger Docs Generation to XML for Swagger CLI
```
builder.Services.AddSwaggerGen(options =>
{
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

	options.IncludeXmlComments($"{AppDomain.CurrentDomain.BaseDirectory}{Path.DirectorySeparatorChar}{Assembly.GetExecutingAssembly().GetName().Name}.xml");
});
```
* Add Routing for Index file

```
// Routing for index page
app.MapGet("/", context =>
{
	context.Response.Redirect("/index.html");
	return Task.CompletedTask;
});
```