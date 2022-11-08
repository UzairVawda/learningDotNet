// create builder sets up the basic features for asp
// creating servires for configuration, logging etc..
using Core;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<FruitOptions>(option =>
{
    option.Name = "Watermelon";
});

// sets up the middleware component
var app = builder.Build();

app.MapGet("/fruit", async (HttpContext context, IOptions<FruitOptions> FruitOptions) => 
{
    FruitOptions options = FruitOptions.Value;
    await context.Response.WriteAsync($"{options.Name}, {options.Color}");

});

app.UseMiddleware<FruitMiddleware>();

// apeget middleware to get route (endpoint) `/` to return string
app.MapGet("/", () => "Hello World!");

// run
app.Run();
