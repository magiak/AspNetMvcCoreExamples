using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetMvcCoreExamples.Entities.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; }
    }
}
