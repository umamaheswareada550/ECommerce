using System;
using Microsoft.Extensions.DependencyInjection;

namespace Mahesh.MicroApp.Core
{
    public static partial class MaheshApp
    {
        private static IServiceProvider _serviceProvider;
        private static IServiceProvider ServiceProvider{
            get{
                if(_serviceProvider==null)
                    throw new Exception("MaheshApp.ServiceProvider is null and must be configured by"+
                    "calling the \"Configure\" method before it can be used.");
                return _serviceProvider;
            }
            set{
                _serviceProvider=value;
            }
        }

        public static T GetRequestService<T>(){
            if(HttpContext?.RequestServices!=null)
                return HttpContext.RequestServices.GetService<T>();
            return default(T);
        }

        public static T GetService<T>()
        {
            var service=ServiceProvider.GetService<T>();
            if(service==null)
                throw new Exception($"Unable to find {typeof(T).FullName} in MaheshAp.ServiceProvider");
            return service;
        }
    }
}