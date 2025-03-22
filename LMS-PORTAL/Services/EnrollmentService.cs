using System.Threading.Tasks;
using LMSCapstone.Models;
using LMSCapstone.Repositories;

namespace LMSCapstone.Services
{
    public interface IEnrollmentService
    {
        Task<bool> EnrollStudentAsync(Enrollment enrollment);
    }

    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }
        public async Task<bool> EnrollStudentAsync(Enrollment enrollment)
        {
            await _enrollmentRepository.AddAsync(enrollment);
            return true;
        }
    }
}
