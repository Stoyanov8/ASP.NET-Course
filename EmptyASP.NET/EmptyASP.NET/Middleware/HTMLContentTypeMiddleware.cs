namespace EmptyASP.NET.Middleware
{
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    public class HTMLContentTypeMiddleware
    {
        private readonly RequestDelegate _next;

        public HTMLContentTypeMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public Task Invoke(HttpContext context)
        {
            context.Response.Headers.Add("Content-Type", "text/html");
            return this._next(context);
        }
    }
}