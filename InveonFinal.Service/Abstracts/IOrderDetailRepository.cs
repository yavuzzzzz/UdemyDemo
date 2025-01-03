using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InveonFinal.Core.Models;
using InveonFinal.Core.Repositories;
using InveonFinal.Service.Dtos.OrderDtos;

namespace InveonFinal.Service.Abstracts
{
    public interface IOrderDetailRepository : IGenericRepository<OrderDetailDto>
    {
        Task<IEnumerable<OrderResponseDto>> GetOrderDetailsByOrderIdAsync(int orderId);
    }
}
