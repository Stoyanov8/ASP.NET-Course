namespace EmptyASP.NET.Extensions
{
    using EmptyASP.NET.Middleware;
    using Microsoft.AspNetCore.Builder;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder builder)
                  => builder.UseMiddleware<DatabaseMiddleware>();

        public static IApplicationBuilder UseHtmlContentType(this IApplicationBuilder builder)
                  => builder.UseMiddleware<HTMLContentTypeMiddleware>();
    }
}