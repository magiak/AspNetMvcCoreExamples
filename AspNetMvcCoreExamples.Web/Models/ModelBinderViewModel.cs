namespace AspNetMvcCoreExamples.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    //[Bind(Exclude = nameof(Name))]
    public class ModelBinderViewModel
    {
        [MaxLength(10)]
        public string Name { get; set; }
        
        public ModelBinderChildViewModel Child { get; set; }
    }
}