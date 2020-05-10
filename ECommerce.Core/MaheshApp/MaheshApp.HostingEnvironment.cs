using Microsoft.AspNetCore.Hosting;

namespace Mahesh.MicroApp.Core
{
    public static partial class MaheshApp
    {
        public static IWebHostEnvironment HostEnvironment=>MaheshApp.GetService<IWebHostEnvironment>();
    }
}