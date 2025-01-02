using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InveonFinal.Core.Models;

namespace InveonFinal.Service.Dtos.OrderDtos
{
    public class OrderCreateDto
    {
        public string UserId { get; set; } = default!;
        public List<OrderDetailDto> OrderDetails { get; set; } = new List<OrderDetailDto>();
    }

}
