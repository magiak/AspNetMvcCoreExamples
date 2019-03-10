namespace AspNetMvcCoreExamples.Business.ModelBinding
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Newtonsoft.Json;
    using System;
    using System.Threading.Tasks;

    public class JsonModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            try
            {
                var value = bindingContext.ValueProvider.GetValue("Json");

                var model = JsonConvert.DeserializeObject(value.FirstValue, bindingContext.ModelType);
                bindingContext.Result = ModelBindingResult.Success(model);
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
