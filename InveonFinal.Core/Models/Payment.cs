using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonFinal.Core.Models
{
    public class Payment
    {   
        public int Id { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? PaymentType { get; set; }
        public string? PaymentStatus { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
