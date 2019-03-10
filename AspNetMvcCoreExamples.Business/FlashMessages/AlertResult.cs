namespace AspNetMvcCoreExamples.Business.FlashMessages
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;

    public class AlertResult : ActionResult
    {
        public IActionResult InnerResult { get; set; }
        public AlertType AlertType { get; set; }
        public string Message { get; set; }

        public AlertResult(
            IActionResult innerResult,
            AlertType alertType,
            string message)
        {
            this.InnerResult = innerResult;
            this.AlertType = alertType;
            this.Message = message;
        }

        public async void ExecuteResultAsync(ControllerContext context)
        {
            ITempDataDictionaryFactory factory = context.HttpContext.RequestServices.GetService(typeof(ITempDataDictionaryFactory)) as ITempDataDictionaryFactory;
            ITempDataDictionary tempData = factory.GetTempData(context.HttpContext);

            await this.InnerResult.ExecuteResultAsync(context);
        }
    }
}
