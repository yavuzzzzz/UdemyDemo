using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InveonFinal.Core.UnitOfWork;

namespace InveonFinal.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommmitAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
