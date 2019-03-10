namespace AspNetMvcCoreExamples.Web.Models
{
    using Validations;

    public class CustomValidationAttributeViewModel
    {
        [GreaterThan(nameof(OtherProperty), "Property has to be greater than OtherProperty")]
        public int Property { get; set; }

        public int OtherProperty { get; set; }
    }
}