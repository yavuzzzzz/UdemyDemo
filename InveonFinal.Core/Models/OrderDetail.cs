using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonFinal.Core.Models
{
    public class OrderDetail
    {   
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } = default!;
        public int CourseId { get; set; }
        public Course Course { get; set; } = default!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
