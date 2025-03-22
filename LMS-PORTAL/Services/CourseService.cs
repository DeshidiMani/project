using System.Collections.Generic;
using System.Threading.Tasks;
using LMSCapstone.Models;
using LMSCapstone.Repositories;

namespace LMSCapstone.Services
{
    public interface ICourseService
    {
        Task<Course> CreateCourseAsync(Course course);
        Task<Course> GetCourseByIdAsync(int id);
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course> UpdateCourseAsync(int id, Course course);
        Task DeleteCourseAsync(int id);
    }

    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<Course> CreateCourseAsync(Course course)
        {
            return await _courseRepository.AddAsync(course);
        }
        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await _courseRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _courseRepository.GetAllAsync();
        }
        public async Task<Course> UpdateCourseAsync(int id, Course course)
        {
            return await _courseRepository.UpdateAsync(id, course);
        }
        public async Task DeleteCourseAsync(int id)
        {
            await _courseRepository.DeleteAsync(id);
        }
    }
}
