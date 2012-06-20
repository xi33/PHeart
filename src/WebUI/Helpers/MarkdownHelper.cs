using System.Web;
using System.Web.Mvc;
using MarkdownSharp;

namespace WebUI.Application.Helpers
{
    public static class MarkdownHelper
    {
        static readonly Markdown MarkdownTransformer=new Markdown();

        public static IHtmlString Markdown(this HtmlHelper helper,string text)
        {
            var html = MarkdownTransformer.Transform(text);
            return MvcHtmlString.Create(html);
        }
    }
}