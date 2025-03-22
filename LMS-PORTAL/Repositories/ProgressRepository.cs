using System.Threading.Tasks;
using LMSCapstone.Models;
using LMSCapstone.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LMSCapstone.Repositories
{
    public interface IProgressRepository
    {
        Task<Progress> GetByUserAndCourseAsync(int userId, int courseId);
        Task<bool> UpdateAsync(int userId, int courseId, Progress progress);
    }

    public class ProgressRepository : IProgressRepository
    {
        private readonly LMSDbContext _context;
        public ProgressRepository(LMSDbContext context)
        {
            _context = context;
        }
        public async Task<Progress> GetByUserAndCourseAsync(int userId, int courseId)
        {
            return await _context.Progresses
                        .FirstOrDefaultAsync(p => p.UserId == userId && p.CourseId == courseId);
        }
        public async Task<bool> UpdateAsync(int userId, int courseId, Progress progress)
        {
            var existing = await _context.Progresses.FirstOrDefaultAsync(p => p.UserId == userId && p.CourseId == courseId);
            if (existing == null)
            {
                await _context.Progresses.AddAsync(progress);
            }
            else
            {
                existing.CompletionPercentage = progress.CompletionPercentage;
                _context.Progresses.Update(existing);
            }
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
