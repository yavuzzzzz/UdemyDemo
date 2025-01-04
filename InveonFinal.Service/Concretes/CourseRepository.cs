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
using InveonFinal.Service.Dtos.CourseDtos;
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

        public Task AddAsync(CourseResponseDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseResponseDto>> GetOrdersByCategoryAsync(CourseResponseDto courseResponseDto)
        {
            throw new NotImplementedException();
        }

        public void Remove(CourseResponseDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseResponseDto>> SearchCoursesAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public CourseResponseDto Update(CourseResponseDto entity)
        {
            throw new NotImplementedException();
        }

        Task<IQueryable<CourseResponseDto>> IGenericRepository<CourseResponseDto>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<CourseResponseDto?> IGenericRepository<CourseResponseDto>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
