using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InveonFinal.Core.Models;
using InveonFinal.Core.Repositories;
using InveonFinal.Service.Dtos.CourseDtos;

namespace InveonFinal.Service.Repositories.Abstracts
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<IEnumerable<Course>> GetCoursesByCategoryAsync(string category);  
        Task<IEnumerable<Course>> SearchCoursesAsync(string searchTerm); 
    }

}
