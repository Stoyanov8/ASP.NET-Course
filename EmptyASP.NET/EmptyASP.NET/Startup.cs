namespace EmptyASP.NET
{
    using EmptyASP.NET.Data;
    using EmptyASP.NET.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FluffyCatsContext>(op => op.UseSqlServer("Server=.;Database=FluffyCats;Integrated Security=True;"));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDatabaseMigration();

            app.UseHtmlContentType();

            app.MapWhen(x => x.Request.Path.Value == "/" && x.Request.Method == "GET",
                    home =>
                            {
                                home.Run(async (context) =>
                                {
                                    await context.Response.WriteAsync("<h1>Fluffy Duffy Munchkin Cats</h1>");
                                    var db = context.RequestServices.GetRequiredService<FluffyCatsContext>();
                                    var cats = db.Cats.Select(c => new
                                    {
                                        c.Id,
                                        c.Name
                                    }).ToList();
                                    await context.Response.WriteAsync("<ul>");

                                    foreach (var cat in cats)
                                    {
                                        await context.Response.WriteAsync($@"<li><a href=/cats/{cat.Id}>{cat.Name}</a></li>");
                                    }
                                    await context.Response.WriteAsync("</ul>");
                                    await context.Response.WriteAsync(@"<form action=""/cat/add""><input type=""submit"" value =""Add Cat"" /></form>");
                                });
                            });
            app.UseStaticFiles();

            app.MapWhen(x => x.Request.Path.Value == "/cat/add",
                cat =>
                {
                    cat.Run(async (context) =>
                    {
                        if (context.Request.Method == "GET")
                        {
                            context.Response.StatusCode = 302;
                            context.Response.Headers.Add("Location", "/add-cat.html");
                        }
                        else
                        {
                            var db = context.RequestServices.GetRequiredService<FluffyCatsContext>();

                            var formDate = context.Request.Form;
                            try
                            {
                                db.Add(new Cat
                                {
                                    Name = formDate["name"],
                                    Age = int.Parse(formDate["age"]),
                                    Breed = formDate["breed"],
                                    ImageUrl = formDate["ImageUrl"],
                                });
                                await db.SaveChangesAsync();
                                context.Response.StatusCode = 302;
                                context.Response.Redirect("/");
                            }
                            catch
                            {
                                await context.Response.WriteAsync(@"<p>Invalid cat data!</p>");
                                await context.Response.WriteAsync(@"<a href=""/cat/add"">Back To Form</a>");
                            }
                        }
                    });
                });

            app.MapWhen(x => x.Request.Path.Value.StartsWith("/cats") && x.Request.Method == "GET",
                catInfo =>
                {
                    catInfo.Run(async (context) =>
                    {
                        var db = context.RequestServices.GetRequiredService<FluffyCatsContext>();

                        using (db)
                        {
                            var parts = (context.Request.Path.Value.Split("/", System.StringSplitOptions.RemoveEmptyEntries));

                            int id = int.Parse(parts[1]);

                            var cat = db.Cats.FirstOrDefault(x => x.Id == id);

                            await context.Response.WriteAsync($@"<h1>{cat.Name}</h1><br />");
                            await context.Response.WriteAsync($@"<img src=""{cat.ImageUrl}"" alt=""{cat.Name}"" width=""300""/>");
                            await context.Response.WriteAsync($@"<p>Age:{cat.Age} <br/></p>");
                            await context.Response.WriteAsync($@"<p>Breed:{cat.Breed} <br/></p>");
                            await context.Response.WriteAsync(@"<a href=""/"">Home</a>");
                        }
                    });
                });

            app.Run(async (context) =>
              {
                  await context.Response.WriteAsync("<h1>Eror 404 page not found</h1>");
              });
        }
    }
}