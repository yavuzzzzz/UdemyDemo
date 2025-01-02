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
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Course>> GetOrdersByCategoryAsync(string category)
        {
            return await _context.Courses
                                 .Where(c => c.Category == category)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Course>> SearchCoursesAsync(string searchTerm)
        {
            return await _context.Courses
                                 .Where(c => c.Name.Contains(searchTerm) || c.Description.Contains(searchTerm))
                                 .ToListAsync();
        }
    }
}
