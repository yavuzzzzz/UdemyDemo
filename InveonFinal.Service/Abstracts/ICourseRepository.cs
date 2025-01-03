using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InveonFinal.Core.Models;
using InveonFinal.Core.Repositories;
using InveonFinal.Service.Dtos.CourseDtos;

namespace InveonFinal.Service.Abstracts
{
    public interface ICourseRepository : IGenericRepository<CourseResponseDto>
    {
        Task<IEnumerable<CourseResponseDto>> GetOrdersByCategoryAsync(CourseResponseDto courseResponseDto);

        Task<IEnumerable<CourseResponseDto>> SearchCoursesAsync(string searchTerm);
    }
}
