using System;
using Mahesh.MicroApp.Core.Configuration;
using Microsoft.Extensions.Configuration;

namespace Mahesh.MicroApp.Core
{
    public static partial class MaheshApp
    {
        private static MicroAppCoreConfiguration _configuration=null;
        public static MicroAppCoreConfiguration Configuration{
            get{
                if(_configuration==null)
                    throw new Exception("Configuration has not been set! Please call \"MicroApp.SetConfiguration\" method prior to accessing the \"Configuration\" property.");
                return _configuration;
            }
            set{
                _configuration=value;
            }
        }

        public static void SetConfiguration(IConfiguration configuration)
        {
            Configuration=new MicroAppCoreConfiguration();
            // Configuration.Bind(configuration.GetSection(MicroAppCoreConfiguration));
        }
    }
}