namespace AspNetMvcCoreExamples.Web.HtmlHelpers
{
    using AspNetMvcCoreExamples.Business.FlashMessages;
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Text;

    public static class FlashMessagesHtmlHelperExtensions
    {
        public static IHtmlContent FlashMessages(this IHtmlHelper htmlHelper, bool dismissible = false)
        {
            var stringBuilder = new StringBuilder();
            var alerts = htmlHelper.ViewContext.TempData.GetAllAlerts();
            foreach (Alert alert in alerts)
            {

                var tagBuilder = new TagBuilder("div");
                tagBuilder.MergeAttribute("role", "alert");
                tagBuilder.AddCssClass("alert");
                tagBuilder.AddCssClass($"alert-{alert.AllertType.ToString().ToLower()}");

                if (dismissible)
                {
                    tagBuilder.AddCssClass("alert-dismissible");
                    tagBuilder.InnerHtml.AppendHtml("<button type=\"button\" class=\"close\" " +
                        "data-dismiss=\"alert\" aria-label=\"Close\">" +
                        "<span aria-hidden=\"true\">&times;</span></button>");
                }

                tagBuilder.InnerHtml.AppendHtml($"<span>{alert.Message}</span>");

                stringBuilder.AppendLine(tagBuilder.ToString());
            }

            alerts.Clear();

            return new HtmlString(stringBuilder.ToString());
        }
    }
}