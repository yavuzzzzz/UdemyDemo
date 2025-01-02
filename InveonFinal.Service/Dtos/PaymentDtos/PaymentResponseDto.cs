using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonFinal.Service.Dtos.PaymentDtos
{
    public class PaymentResponseDto
    {
        public int PaymentId { get; set; }
        public string PaymentStatus { get; set; } = default!;
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }

}
