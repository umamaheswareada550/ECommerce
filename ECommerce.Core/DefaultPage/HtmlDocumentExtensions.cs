using HtmlAgilityPack;

namespace Mahesh.MicroApp.Core.DefaultPage
{
    public static class HtmlDocumentExtensions
    {
        public static HtmlNode GetBodyNode(this HtmlDocument htmlDocument){
            return htmlDocument?.DocumentNode?.SelectSingleNode("//body");
        }
        public static void PrependToBodyNode(this HtmlDocument htmlDocument,string html){
            htmlDocument?.GetBodyNode()?.PrependChild(HtmlNode.CreateNode(html));
        }
    }
}