namespace AspNetMvcCoreExamples.Business.ModelBinding
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System;
    using System.Threading.Tasks;

    public class DayMonthYearModelBinder : IModelBinder
    {
        // TODO ModelBinderProvider
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            try
            {
                var modelName = bindingContext.ModelName;
                var yearResult = bindingContext.ValueProvider.GetValue($"{modelName}.Year");
                var monthResult = bindingContext.ValueProvider.GetValue($"{modelName}.Month");
                var dayResult = bindingContext.ValueProvider.GetValue($"{modelName}.Day");

                int year = int.Parse(yearResult.FirstValue);
                int month = int.Parse(monthResult.FirstValue);
                int day = int.Parse(dayResult.FirstValue);

                bindingContext.Result = ModelBindingResult.Success(new DateTime(year, month, day));
                return Task.CompletedTask;
            }
            catch (Exception)
            {
                bindingContext.ModelState.AddModelError("Error", "Can not bind value to model");
                return Task.CompletedTask;
            }
        }
    }
}
