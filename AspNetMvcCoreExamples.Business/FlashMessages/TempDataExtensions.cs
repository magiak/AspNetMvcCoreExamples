namespace AspNetMvcCoreExamples.Business.FlashMessages
{
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using System.Collections.Generic;

    public static class TempDataExtensions
    {
        private const string TempDataKey = "FlashMessages";

        public static List<Alert> GetAllAlerts(this ITempDataDictionary tempData)
        {
            if (!tempData.ContainsKey(TempDataKey))
            {
                tempData[TempDataKey] = new List<Alert>();
            }

            return (List<Alert>)tempData[TempDataKey];
        }

        public static void AddAlert(this ITempDataDictionary tempData, AlertType alertType, string message)
        {
            var alerts = tempData.GetAllAlerts();
            alerts.Add(new Alert()
            {
                AllertType = alertType,
                Message = message
            });
        }
    }
}
