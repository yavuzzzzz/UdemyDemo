using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InveonFinal.Service.Dtos.CourseDtos;
using Microsoft.AspNetCore.Mvc;

namespace InveonFinal.Service.Services.Abstract
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseResponseDto>> GetCoursesByCategoryAsync(string category);
        Task<IEnumerable<CourseResponseDto>> SearchCoursesAsync(string searchTerm);
        Task<ProblemDetails?> AddCourseAsync(CourseCreateDto courseCreateDto);
        Task<ProblemDetails?> UpdateCourseAsync(int id, CourseUpdateDto courseUpdateDto);
        Task<ProblemDetails?> RemoveCourseAsync(int id);
    }


}
