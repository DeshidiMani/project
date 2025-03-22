using LMSCapstone.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using LMSCapstone.Data;
using Microsoft.EntityFrameworkCore;

namespace LMSCapstone.Repositories
{
    public interface ICourseRepository
    {
        Task<Course> AddAsync(Course course);
        Task<Course> GetByIdAsync(int id);
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course> UpdateAsync(int id, Course course);
        Task DeleteAsync(int id);
    }
    public class CourseRepository : ICourseRepository
    {
        private readonly LMSDbContext _context;
        public CourseRepository(LMSDbContext context)
        {
            _context = context;
        }
        public async Task<Course> AddAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
            return course;
        }
        public async Task<Course> GetByIdAsync(int id)
        {
            return await _context.Courses.FindAsync(id);
        }
        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses.ToListAsync();
        }
        public async Task<Course> UpdateAsync(int id, Course course)
        {
            var existing = await _context.Courses.FindAsync(id);
            if (existing == null) return null;
            existing.Title = course.Title;
            existing.Description = course.Description;
            existing.Category = course.Category;
            existing.Difficulty = course.Difficulty;
            _context.Courses.Update(existing);
            await _context.SaveChangesAsync();
            return existing;
        }
        public async Task DeleteAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
        }
    }
}
