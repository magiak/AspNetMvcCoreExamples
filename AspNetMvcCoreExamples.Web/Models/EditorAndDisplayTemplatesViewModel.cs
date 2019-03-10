namespace AspNetMvcCoreExamples.Web.Models
{
    using AspNetMvcCoreExamples.Entities.Enums;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class EditorAndDisplayTemplatesViewModel
    {
        public decimal Price { get; set; }

        public Genre Genre { get; set; }

        public int Month { get; set; }

        public List<SelectListItem> MonthItems { get; set; }

        [UIHint("Months")]
        public int Month2 { get; set; }
    }
}