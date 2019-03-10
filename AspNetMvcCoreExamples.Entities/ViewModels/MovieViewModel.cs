using AspNetMvcCoreExamples.Entities.Enums;
using System;

namespace AspNetMvcCoreExamples.Entities.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        // TODO [UIHint("shortdatetime")]
        public DateTime ReleasedDate { get; set; }
        public decimal Price { get; set; }
    }
}
