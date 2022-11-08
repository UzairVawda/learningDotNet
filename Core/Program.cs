// create builder sets up the basic features for asp
// creating servires for configuration, logging etc..
using Core;

var builder = WebApplication.CreateBuilder(args);

// sets up the middleware component
var app = builder.Build();

// working with the reques and passing it through middlewares

// // when any get request with custom = true query string
// app.Use(async (context, next) =>
// {
// if (context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true")
// {
// context.Response.ContentType = "text/plain";
// await context.Response.WriteAsync("Custom MiddleWare\n");
//     }
// await next();
//     // awaire next().invoke
// });

// changing the request as it is being passed 
// app.Use(async (context, next) => 
// {
// await next();
// await context.Response.WriteAsync($"\nStatus code: {context.Response.StatusCode}");

// if (context.Request.Path == "/short")
// {
// await context.Response.WriteAsync("REQUEST SHORT CIRCUIT");
//     } 
//     else
// {
// await next();
//     }
// });

// terminal middleware

((IApplicationBuilder)app).Map("/branch", branch =>
{
    branch.Run(new Middleware().Invoke);
});


app.UseMiddleware<Middleware>();


// apeget middleware to get route (endpoint) `/` to return string
app.MapGet("/", () => "Hello World!");


// run
app.Run();
