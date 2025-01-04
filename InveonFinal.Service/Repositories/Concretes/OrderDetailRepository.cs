using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InveonFinal.Core.Models;
using InveonFinal.Core.Repositories;
using InveonFinal.Core.UnitOfWork;
using InveonFinal.Data;
using InveonFinal.Data.Repositories;
using InveonFinal.Service.Dtos.OrderDtos;
using InveonFinal.Service.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace InveonFinal.Service.Repositories.Concretes
{
    public class OrderDetailRepository(AppDbContext context, IUnitOfWork unitOfWork) : GenericRepository<OrderDetail>(context, unitOfWork), IOrderDetailRepository
    {
        private readonly DbSet<OrderDetail>? _dbSet;

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderIdAsync(int orderId)
        {
            return await _dbSet.Where(od => od.OrderId == orderId).ToListAsync();
        }
    }

}
