using System.Threading.Tasks;
using LMSCapstone.Models;
using LMSCapstone.Repositories;

namespace LMSCapstone.Services
{
    public interface IProgressService
    {
        Task<Progress> GetProgressAsync(int userId, int courseId);
        Task<bool> UpdateProgressAsync(int userId, int courseId, Progress progress);
    }

    public class ProgressService : IProgressService
    {
        private readonly IProgressRepository _progressRepository;
        public ProgressService(IProgressRepository progressRepository)
        {
            _progressRepository = progressRepository;
        }
        public async Task<Progress> GetProgressAsync(int userId, int courseId)
        {
            return await _progressRepository.GetByUserAndCourseAsync(userId, courseId);
        }
        public async Task<bool> UpdateProgressAsync(int userId, int courseId, Progress progress)
        {
            return await _progressRepository.UpdateAsync(userId, courseId, progress);
        }
    }
}
