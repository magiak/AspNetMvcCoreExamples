namespace AspNetMvcCoreExamples.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class DataAnnotationsValidationViewModel
    {
        [Required]
        public string Required { get; set; }

        [StringLength(10, MinimumLength = 5)]
        public string StringLength { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Range(1, 12)]
        public int Range { get; set; }

        // \D => Matches any character other than a decimal digit.
        [RegularExpression("\\D")]
        public string RegularExpression { get; set; }
    }
}