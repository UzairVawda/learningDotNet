using Core.Services;
using Microsoft.Extensions.Options;

namespace Core
{
    public class CustomMiddleware
    {
        private RequestDelegate _next;
        private IResponseFormatter _formatter;

        public CustomMiddleware(RequestDelegate next, IResponseFormatter formatter)
        {
            _next = next;
            _formatter = formatter;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/csmiddle")
            {
                await _formatter.Format(context, "Customer Middle");
            }
            else
            {
                await _next(context);
            }
        }
    }
}
