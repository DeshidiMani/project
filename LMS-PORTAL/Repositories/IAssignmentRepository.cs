using System.Collections.Generic;
using System.Threading.Tasks;
using LMSCapstone.Models;

namespace LMSCapstone.Repositories
{
    public interface IAssignmentRepository
    {
        Task<Assignment> AddAsync(Assignment assignment);
        Task<Assignment> GetByIdAsync(int id);
        Task<AssignmentSubmission> AddSubmissionAsync(int assignmentId, AssignmentSubmission submission);
        Task<AssignmentSubmission> GradeSubmissionAsync(int submissionId, double grade);
        // NEW: Get assignments by course Id
        Task<IEnumerable<Assignment>> GetByCourseAsync(int courseId);
    }
}
