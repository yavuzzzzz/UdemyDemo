using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonFinal.Core.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Category { get; set; } = default!;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }



    }
}
