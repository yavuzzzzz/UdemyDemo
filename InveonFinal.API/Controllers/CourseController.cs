using InveonFinal.Service.Dtos.CourseDtos;
using InveonFinal.Service.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InveonFinal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("category/{category}")]
        public async Task<IActionResult> GetCoursesByCategory(string category)
        {
            var courses = await _courseService.GetCoursesByCategoryAsync(category);
            return Ok(courses);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchCourses([FromQuery] string searchTerm)
        {
            var courses = await _courseService.SearchCoursesAsync(searchTerm);
            return Ok(courses);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(CourseCreateDto courseCreateDto)
        {
            var result = await _courseService.AddCourseAsync(courseCreateDto);
            if (result != null) return BadRequest(result);

            return Ok("Course added successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, CourseUpdateDto courseUpdateDto)
        {
            var result = await _courseService.UpdateCourseAsync(id, courseUpdateDto);
            if (result != null) return NotFound(result);

            return Ok("Course updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var result = await _courseService.RemoveCourseAsync(id);
            if (result != null) return NotFound(result);

            return Ok("Course deleted successfully.");
        }
    }


}
