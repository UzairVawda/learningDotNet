// create builder sets up the basic features for asp
// creating servires for configuration, logging etc..

using Core;
using Core.Services;

var builder = WebApplication.CreateBuilder(args);


// dependency indenjection using singltion which uses the same instence
builder.Services.AddSingleton<IResponseFormatter, HtmlResponseFormatter>();

// sets up the middleware component
var app = builder.Build();


// IResponseFormatter formatter = new TextResponseFormatter(); 

app.MapGet("/formatter1", async (HttpContext context, IResponseFormatter formatter) =>
{
    await formatter.Format(context, "Formatter 1");
});

app.MapGet("/formatter2", async (HttpContext context, IResponseFormatter formatter) =>
{
    await formatter.Format(context, "Formatter 2");
});

app.UseMiddleware<CustomMiddleware>();

app.MapGet("/endpoint", CustomEndpoint.Endpoint);

// apeget middleware to get route (endpoint) `/` to return string
app.MapGet("/", () => "Hello World!");

// run
app.Run();
