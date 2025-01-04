using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InveonFinal.Core.Models;
using InveonFinal.Service.Dtos.PaymentDtos;

namespace InveonFinal.Service.Dtos.OrderDtos
{
    public class OrderResponseDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = default!;
        public string CourseName { get; set; } = default!;
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; } = default!;
        public PaymentResponseDto? Payment { get; set; }
    }

}
