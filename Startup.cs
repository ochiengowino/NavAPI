using Microsoft.Owin;
using Owin;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using API.Context;
using System.Web.Http;

[assembly: OwinStartup(typeof(API.Startup))]

namespace API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
         

            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            /* app.Use((context, next) =>
             {
                 TextWriter output = context.Get<TextWriter>("host.TraceOutput");
                 return next().ContinueWith(result =>
                 {
                     output.WriteLine("Scheme {0} : Method {1} : Path {2} : MS {3}",
                     context.Request.Scheme, context.Request.Method, context.Request.Path, getTime());
                 });
             });

             app.Run(async context =>
             {
                 await context.Response.WriteAsync(getTime() + " My First OWIN App");
             });*/
        }

      /*  public static string GetConnectionString()
        {
            var connection = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            *//*if (connection != null && !string.IsNullOrWhiteSpace(connection.ConnectionString))
            {
                return connection.ConnectionString;
            }*//*
            return connection.ConnectionString;

        }*/

        /* public static NavContext GetMyDbContext(string MobiApiDB)
         {
             var optionsBuilder = new DbContextOptionsBuilder<NavContext>();

             optionsBuilder.UseSqlServer($@"Data Source=.OCHIENGOWINO\\SQLEXPRESS01 Catalog={MobiApiDB};Integrated Security=True; Trusted_Connection=True; MultipleActiveResultSets=True; TrustServerCertificate=True");

             return new NavContext(optionsBuilder.Options);

         }*/
        /*string getTime()
        {
            return DateTime.Now.Millisecond.ToString();
        }*/

        /*public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Server=OCHIENGOWINO\\NAVDEMO; Database=LoanApplication; Trusted_Connection=True; MultipleActiveResultSets=True; TrustServerCertificate=True";
            services.AddDbContextPool<NavContext>(
                               options => options.UseSqlServer(connection));

            *//*      services.AddDbContext<NavContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));*//*
        }*/
    }
}
