using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetMvcCoreExamples.Web.HtmlHelpers
{
    public static class ModalHtmlHelperExtensions
    {
        public static IHtmlContent ModalButton(this IHtmlHelper htmlHelper, string id, string text)
        {
            var result = 
$@"<button type=""button"" class=""btn btn-primary"" data-toggle=""modal"" data-target=""#{id}"">
  {text}
</button>";

            return new HtmlString(result);
        }
        
        public static IHtmlContent Modal(this IHtmlHelper htmlHelper,
            string id,
            string title,
            string body,
            string primary = "Submit",
            string secondary = "Close")
        {
            var result = 
$@"<div class=""modal"" tabindex=""-1"" role=""dialog"" id=""{id}"">
  <div class=""modal-dialog"" role=""document"">
    <div class=""modal-content"">
      <div class=""modal-header"">
        <h5 class=""modal-title"">{title}</h5>
        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
          <span aria-hidden=""true"">&times;</span>
        </button>
      </div>
      <div class=""modal-body"">
        <p>{body}</p>
      </div>
      <div class=""modal-footer"">
        <button type=""button"" class=""btn btn-primary"">{primary}</button>
        <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">{secondary}</button>
      </div>
    </div>
  </div>
</div>";
            
            return new HtmlString(result);
        }

        public static IHtmlContent ModalPartial(this IHtmlHelper htmlHelper,
            string id,
            string title,
            string body,
            string primary = "Submit",
            string secondary = "Close")
        {
            return htmlHelper.Partial("_ModalTemplate", id);
        }
    }
}