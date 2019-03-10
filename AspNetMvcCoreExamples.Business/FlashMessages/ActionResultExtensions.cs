using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcCoreExamples.Business.FlashMessages
{
    public static class ActionResultExtensions
    {
        public static IActionResult WithAlert(this IActionResult result, AlertType alertType, string message)
        {
            return new AlertResult(result, alertType, message);
        }

        public static IActionResult WithSuccessAlert(this IActionResult result, string message)
        {
            return new AlertResult(result, AlertType.Success, message);
        }

        public static IActionResult WithInfoAlert(this IActionResult result, string message)
        {
            return new AlertResult(result, AlertType.Info, message);
        }

        public static IActionResult WithWarningAlert(this IActionResult result, string message)
        {
            return new AlertResult(result, AlertType.Warning, message);
        }

        public static IActionResult WithErrorAlert(this IActionResult result, string message)
        {
            return new AlertResult(result, AlertType.Danger, message);
        }
    }
}
