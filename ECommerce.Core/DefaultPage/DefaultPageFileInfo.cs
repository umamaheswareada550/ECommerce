using System;
using System.IO;
using Microsoft.Extensions.FileProviders;

namespace Mahesh.MicroApp.Core.DefaultPage
{
    public class DefaultPageFileInfo:IFileInfo
    {
        DefaultPage _defaultPage;
        public DefaultPageFileInfo(DefaultPage defaultPage)
        {
            this._defaultPage=defaultPage;
        }
        public bool Exists => _defaultPage.FileExists;

        public long Length => _defaultPage.Stream.Length;

        public string PhysicalPath => null;

        public string Name => _defaultPage.FileName;

        public DateTimeOffset LastModified => _defaultPage.LastModified;

        public bool IsDirectory => false;

        public Stream CreateReadStream()
        {
            return _defaultPage.Stream;
        }

    }
}