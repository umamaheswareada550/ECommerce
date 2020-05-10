using System;
using System.IO;
using HtmlAgilityPack;

namespace Mahesh.MicroApp.Core.DefaultPage
{
    public class DefaultPageBuilder
    {
        private static string _directoryPath=null;
        private static string _filePath=null;
        private static string OriginalHtml { 
            get{
                return File.ReadAllText(FilePath);
            }
        }
        private static string Html{
            get{
                return ProcessOriginalHtml(OriginalHtml);
            }
        }

        private static string ProcessOriginalHtml(string html){
            var htmlDocument=new HtmlDocument();
            htmlDocument.LoadHtml(html);
            // UpdateRelativeUrisToAbsolute(htmlDocument);
            return htmlDocument.DocumentNode.OuterHtml;
        }

        public DefaultPage Build(){
            var htmlDocument=new HtmlDocument();
            htmlDocument.LoadHtml(Html);
            htmlDocument.PrependToBodyNode($"<!--<div>{DateTime.Now.ToString()}</div>-->");
            return new DefaultPage(FilePath,htmlDocument.DocumentNode.OuterHtml);
        }
        public static Action<HtmlDocument> AuxiliaryBuilder{get;set;}=null;
        public static string FilePath => _filePath??= Path.Combine(DirectoryPath,MaheshApp.Configuration.ClientApp.DefaultPage.FileName);

        public static string DirectoryPath => _directoryPath??=Path.Combine(MaheshApp.HostEnvironment.ContentRootPath,MaheshApp.Configuration.ClientApp.RootPath);
    }
}