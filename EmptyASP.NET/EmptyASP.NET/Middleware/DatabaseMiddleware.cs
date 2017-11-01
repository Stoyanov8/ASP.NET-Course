namespace EmptyASP.NET.Middleware
{
    using EmptyASP.NET.Data;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;

    public class DatabaseMiddleware
    {
        private readonly RequestDelegate _next;

        public DatabaseMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public Task Invoke(HttpContext context)
        {
            context.RequestServices.GetRequiredService<FluffyCatsContext>().Database.Migrate();

            return this._next(context);
        }
    }
}