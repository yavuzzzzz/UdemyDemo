using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InveonFinal.Core.Models;
using InveonFinal.Core.Repositories;

namespace InveonFinal.Service.Abstracts
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<IEnumerable<Course>> GetOrdersByCategoryAsync(string category);

        Task<IEnumerable<Course>> SearchCoursesAsync(string searchTerm);
    }
}
