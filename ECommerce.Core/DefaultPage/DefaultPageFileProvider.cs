using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

namespace Mahesh.MicroApp.Core.DefaultPage
{
    public class DefaultPageFileProvider : IFileProvider
    {
        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            return new PhysicalFileProvider(Path.Combine(MaheshApp.HostEnvironment.ContentRootPath,MaheshApp.Configuration.ClientApp.RootPath))?.GetDirectoryContents(subpath);
        }

        public IFileInfo GetFileInfo(string subpath)
        {
            return MaheshApp.GetRequestService<DefaultPageFileInfo>();
        }

        public IChangeToken Watch(string filter)
        {
            throw new System.NotImplementedException("Watch not implemened");
        }
    }
}