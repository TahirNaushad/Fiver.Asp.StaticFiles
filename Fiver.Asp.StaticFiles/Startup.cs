using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace Fiver.Asp.StaticFiles
{
    public class Startup
    {
        public void ConfigureServices(
            IServiceCollection services)
        {
        }

        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env)
        {
            app.UseStaticFiles(); // for files in wwwroot folder

            app.UseStaticFiles(new StaticFileOptions() // for files in content folder
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "content")),
                RequestPath = new PathString("/outside-content")
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello Static Files");
            });
        }
    }
}
