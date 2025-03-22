using LMSCapstone.Models;
using System.Threading.Tasks;
using LMSCapstone.Data;
using Microsoft.EntityFrameworkCore;

namespace LMSCapstone.Repositories
{
    public interface IVideoRepository
    {
        Task<Video> AddAsync(Video video);
        Task<Video> GetByIdAsync(int id);
    }

    public class VideoRepository : IVideoRepository
    {
        private readonly LMSDbContext _context;

        public VideoRepository(LMSDbContext context)
        {
            _context = context;
        }

        public async Task<Video> AddAsync(Video video)
        {
            await _context.Videos.AddAsync(video);
            await _context.SaveChangesAsync();
            return video;
        }

        public async Task<Video> GetByIdAsync(int id)
        {
            return await _context.Videos.FindAsync(id);
        }
    }
}
