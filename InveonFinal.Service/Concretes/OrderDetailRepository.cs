using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InveonFinal.Core.Models;
using InveonFinal.Core.Repositories;
using InveonFinal.Data;
using InveonFinal.Data.Repositories;
using InveonFinal.Service.Abstracts;
using InveonFinal.Service.Dtos.OrderDtos;
using Microsoft.EntityFrameworkCore;

namespace InveonFinal.Service.Concretes
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        private readonly AppDbContext _context;
        public OrderDetailRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Task AddAsync(OrderDetailDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> GetOrderDetailsByOrderIdAsync(int orderId)
        {
             return await _context.Orders
                                  .Where(o => o.Id == orderId)
                                  .ToListAsync();
        }

        public void Remove(OrderDetailDto entity)
        {
            throw new NotImplementedException();
        }

        public OrderDetailDto Update(OrderDetailDto entity)
        {
            throw new NotImplementedException();
        }

        Task<IQueryable<OrderDetailDto>> IGenericRepository<OrderDetailDto>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<OrderDetailDto?> IGenericRepository<OrderDetailDto>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<OrderResponseDto>> IOrderDetailRepository.GetOrderDetailsByOrderIdAsync(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
