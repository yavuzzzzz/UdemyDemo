using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InveonFinal.Service.Dtos.OrderDtos;
using Microsoft.AspNetCore.Mvc;

namespace InveonFinal.Service.Services.Abstract
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetailDto>> GetOrderDetailsByOrderIdAsync(int orderId);
        Task<ProblemDetails?> AddOrderDetailAsync(OrderDetailDto orderDetailDto);
        Task<ProblemDetails?> RemoveOrderDetailAsync(int id);
    }


}
