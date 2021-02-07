using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace Equals_App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Container(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
         

            app.UseExceptionHandler(
              options =>
              {
                  options.Run(
                      async context =>
                      {
                          context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                          context.Response.ContentType = "text/html";
                          var exceptionObject = context.Features.Get<IExceptionHandlerFeature>();
                          if (null != exceptionObject)
                          {
                              var errorMessage = $"<b>Error: {exceptionObject.Error.Message}</b> {exceptionObject.Error.StackTrace}";

                              await context.Response.WriteAsync(errorMessage).ConfigureAwait(false);
                          }
                      });
              }
          );
            app.UseMvcWithDefaultRoute();
            app.UseMvc();
        }

        private static void Container(IServiceCollection service)
        {
            Equals_IOC.Docker.Register(service);
        }
    }
}
