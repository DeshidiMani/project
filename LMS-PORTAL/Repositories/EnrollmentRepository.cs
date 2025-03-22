using System.Threading.Tasks;
using LMSCapstone.Models;
using LMSCapstone.Data;

namespace LMSCapstone.Repositories
{
    public interface IEnrollmentRepository
    {
        Task AddAsync(Enrollment enrollment);
    }

    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly LMSDbContext _context;
        public EnrollmentRepository(LMSDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Enrollment enrollment)
        {
            await _context.Enrollments.AddAsync(enrollment);
            await _context.SaveChangesAsync();
        }
    }
}
