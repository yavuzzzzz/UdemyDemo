using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InveonFinal.Core.Models;
using InveonFinal.Service.Dtos.OrderDtos;
using InveonFinal.Service.Repositories.Abstracts;
using InveonFinal.Service.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InveonFinal.Service.Services.Concretes
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<IEnumerable<OrderDetailDto>> GetOrderDetailsByOrderIdAsync(int orderId)
        {
            var orderDetails = await _orderDetailRepository.GetOrderDetailsByOrderIdAsync(orderId);
            return orderDetails.Select(od => new OrderDetailDto
            {
                Id = od.Id,
                OrderId = od.OrderId,
                CourseId = od.CourseId,
                Quantity = od.Quantity,
                Price = od.Price
            });
        }

        public async Task<ProblemDetails?> AddOrderDetailAsync(OrderDetailDto orderDetailDto)
        {
            var orderDetail = new OrderDetail
            {
                OrderId = orderDetailDto.OrderId,
                CourseId = orderDetailDto.CourseId,
                Quantity = orderDetailDto.Quantity,
                Price = orderDetailDto.Price
            };

            await _orderDetailRepository.AddAsync(orderDetail);
            return null;
        }

        public async Task<ProblemDetails?> RemoveOrderDetailAsync(int id)
        {
            var orderDetail = await _orderDetailRepository.GetByIdAsync(id);
            if (orderDetail == null)
            {
                return new ProblemDetails
                {
                    Title = "Order Detail Not Found",
                    Status = StatusCodes.Status404NotFound,
                    Detail = "The specified order detail does not exist."
                };
            }

            await _orderDetailRepository.RemoveAsync(orderDetail);
            return null;
        }
    }


}
