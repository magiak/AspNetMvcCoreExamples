namespace AspNetMvcCoreExamples.Web.HtmlHelpers
{
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Web;

    public static class HighlightsJsExtension
    {
        public static IHtmlContent CodeSection(this IHtmlHelper html, string code)
        {
            code = HttpUtility.HtmlDecode(code);
            code = html.Encode(code);
            var result = $@"<div class=""hljs-wrapper""><pre><code class=""html"">{code}</code></pre></div>";

            return new HtmlString(result);
        }
    }
}