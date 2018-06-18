using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PaymentDateCalculator.Api.Core
{
    public class DateTimeModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            // Try to fetch the value of the argument by name
            var ModelName           = bindingContext.ModelName;
            var ValueProviderResult = bindingContext.ValueProvider.GetValue(ModelName);
            if (ValueProviderResult == ValueProviderResult.None)
                return Task.CompletedTask;

            bindingContext.ModelState.SetModelValue(ModelName, ValueProviderResult);

            var dateStr = ValueProviderResult.FirstValue;
            // Here you define your custom parsing logic, i.e. using "de-DE" culture
            if (!DateTime.TryParse(dateStr, new CultureInfo("tr-TR"), DateTimeStyles.None, out DateTime Date))
            {
                bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, "DateTime should be in format 'dd.MM.yyyy HH:mm:ss'");
                return Task.CompletedTask;
            }

            bindingContext.Result = ModelBindingResult.Success(Date);
            return Task.CompletedTask;
        }
    }
    public class DateTimeModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(DateTime) || 
                context.Metadata.ModelType == typeof(DateTime?))
            {
                return new DateTimeModelBinder();
            }

            return null;
        }
    }
}
