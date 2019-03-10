using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetMvcCoreExamples.Web.Validations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class GreaterThanAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly string otherPropertyName;

        public GreaterThanAttribute(string otherPropertyName, string errorMessage)
            : base(errorMessage)
        {
            this.otherPropertyName = otherPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;

            var otherPropertyInfo = validationContext.ObjectType.GetProperty(this.otherPropertyName);

            int toValidate = (int)value;
            int referenceProperty = (int)otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

            if (toValidate <= referenceProperty)
            {
                validationResult = new ValidationResult(this.ErrorMessageString);
            }

            return validationResult;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            context.Attributes["data-val"] =  "true";
            context.Attributes["data-val-greaterthan"] = this.ErrorMessage;
            context.Attributes["data-val-otherpropertyname"] = this.otherPropertyName;
        }
    }
}
