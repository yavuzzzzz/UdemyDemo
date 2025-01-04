using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InveonFinal.Core.Models;
using InveonFinal.Service.Dtos.CourseDtos;
using InveonFinal.Service.Repositories.Abstracts;
using InveonFinal.Service.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InveonFinal.Service.Services.Concretes
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<CourseResponseDto>> GetCoursesByCategoryAsync(string category)
        {
            var courses = await _courseRepository.GetCoursesByCategoryAsync(category);
            return courses.Select(c => new CourseResponseDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            });
        }

        public async Task<IEnumerable<CourseResponseDto>> SearchCoursesAsync(string searchTerm)
        {
            var courses = await _courseRepository.SearchCoursesAsync(searchTerm);
            return courses.Select(c => new CourseResponseDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description

            });
        }

        public async Task<ProblemDetails?> AddCourseAsync(CourseCreateDto courseCreateDto)
        {
            var course = new Course
            {
                Name = courseCreateDto.Name,
                Description = courseCreateDto.Description,
                Duration = courseCreateDto.Duration,
                Category = courseCreateDto.Category
            };

            await _courseRepository.AddAsync(course);
            return null;
        }

        public async Task<ProblemDetails?> UpdateCourseAsync(int id, CourseUpdateDto courseUpdateDto)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null)
            {
                return new ProblemDetails
                {
                    Title = "Course Not Found",
                    Status = StatusCodes.Status404NotFound,
                    Detail = "The specified course was not found."
                };
            }

            course.Name = courseUpdateDto.Name;
            course.Description = courseUpdateDto.Description;
            course.Duration = courseUpdateDto.Duration;
            course.Category = courseUpdateDto.Category;

            await _courseRepository.UpdateAsync(course);
            return null;
        }

        public async Task<ProblemDetails?> RemoveCourseAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null)
            {
                return new ProblemDetails
                {
                    Title = "Course Not Found",
                    Status = StatusCodes.Status404NotFound,
                    Detail = "The specified course was not found."
                };
            }

            await _courseRepository.RemoveAsync(course);
            return null;
        }
    }


}
