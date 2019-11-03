using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetMvcCoreExamples.Entities.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
