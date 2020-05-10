using System;
using System.IO;
using System.Text;

namespace Mahesh.MicroApp.Core.DefaultPage
{
    public class DefaultPage : IDisposable
    {
        public DefaultPage(string filePath, string html)
        {
            this.FileName = Path.GetFileName(filePath);
            this.FileExists = true;
            this.Html = html;
            this.LastModified=DateTime.UtcNow;
            this.FilePath=filePath;
            this.Stream=new MemoryStream(Encoding.UTF8.GetBytes(Html),false);
        }
        public bool FileExists { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Html { get; }
        public DateTime LastModified{get;}
        public Stream Stream{get;}
        public void Dispose()
        {
            Stream.Dispose();
        }
    }
}