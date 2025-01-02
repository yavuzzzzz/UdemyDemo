using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InveonFinal.Core.Models;
using InveonFinal.Data;
using InveonFinal.Data.Repositories;
using InveonFinal.Service.Abstracts;
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

        public async Task<IEnumerable<Order>> GetOrderDetailsByOrderIdAsync(int orderId)
        {
             return await _context.Orders
                                  .Where(o => o.Id == orderId)
                                  .ToListAsync();
        }
    }
}
