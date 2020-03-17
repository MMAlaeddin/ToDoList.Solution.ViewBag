using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore; // to use UseMySql
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Models;

namespace ToDoList
{
  public class Startup
  {
    //we've added the connection string (in appsettings.json) and dependencies, we must tell our app what to do with it;
    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json"); // "hey program, look at this file"
      Configuration = builder.Build();
    }

// This will allow us to set our app's connection string.. add the Entity Framework middleware.
    public IConfigurationRoot Configuration { get; set; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();

//  Entity configuration code:

// added a form of Entity that understands MySQL as a service.
      services.AddEntityFrameworkMySql()
      // configure that service to use a particular database context the AddDbContext() method, which will be a representation of our database
        .AddDbContext<ToDoListContext>(options => options
        // "use our default connection"
        .UseMySql(Configuration["ConnectionStrings:DefaultConnection"]));
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseStaticFiles();

      app.UseDeveloperExceptionPage();

      app.UseMvc(routes =>
      {
        routes.MapRoute(
          name: "default",
          template: "{controller=Home}/{action=Index}/{id?}");
      });

      app.Run(async (context) =>
      {
        await context.Response.WriteAsync("Poop!");
      });
    }
  }
}