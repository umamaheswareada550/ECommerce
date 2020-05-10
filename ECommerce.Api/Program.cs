using System;
using System.IO;
using System.Threading.Tasks;
using ECommerce.Infrastructure.Data;
using Mahesh.MicroApp.Api.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ECommerce.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var Services = scope.ServiceProvider;
                var loggerFactory = Services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = Services.GetRequiredService<StoreContext>();
                    await context.Database.MigrateAsync();
                    await StoreContextSeed.SeedAsync(context, loggerFactory);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occured during migration");
                }
            }

            host.Run();
        }



        public static IHostBuilder CreateHostBuilder(string[] args=null,int httpsPort=5001) =>
            Host.CreateDefaultBuilder(args)
                .UseMicroAppCore(args,httpsPort)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .ConfigureAppConfiguration((WebHostBuilderContext hostingContext, IConfigurationBuilder configBuilder) =>
                    {
                        //configBuilder.Sources.Clear();
                        configBuilder
                                .AddEnvironmentVariables()
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true);
                        var settings = configBuilder.Build();
                        configBuilder.AddAzureAppConfiguration(settings["Azure:ConnectionStrings:AppConfig"]);
                    })
                    .UseStartup<Startup>();
                });
    }
}
