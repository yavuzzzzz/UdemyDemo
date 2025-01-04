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
using InveonFinal.Service.Dtos.CourseDtos;
using InveonFinal.Service.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace InveonFinal.Service.Repositories.Concretes
{
    public class CourseRepository(AppDbContext context, IUnitOfWork unitOfWork) : GenericRepository<Course>(context, unitOfWork), ICourseRepository
    {
        private readonly DbSet<Course> _dbSet = context.Set<Course>();

        public async Task<IEnumerable<Course>> GetCoursesByCategoryAsync(string category)
        {
            return await _dbSet.Where(c => c.Category == category).ToListAsync();
        }

        public async Task<IEnumerable<Course>> SearchCoursesAsync(string searchTerm)
        {
            return await _dbSet
                .Where(c => c.Name.Contains(searchTerm) || c.Description.Contains(searchTerm))
                .ToListAsync();
        }
    }

}
