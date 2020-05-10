using System;
using Mahesh.MicroApp.Core.DefaultPage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Mahesh.MicroApp.Api.Extensions
{
    public static partial class IHostBuilderExtensions
    {
        public static IHostBuilder UseMicroAppCore(this IHostBuilder hostBuilder,string[] args, int httpsPort=5001)
        {
            return hostBuilder
            .ConfigureServices((hostBuilderContext,services)=>{
                services.AddTransient<DefaultPageBuilder>();
                services.AddScoped(serviceProvider=>{
                    var defaultPageBuilder=serviceProvider.GetService<DefaultPageBuilder>();
                    return Run(()=>defaultPageBuilder.Build());
                });
            });
        }

        public static T Run<T>(Func<T> codeToExecute){
            return codeToExecute();
        }
    }
}