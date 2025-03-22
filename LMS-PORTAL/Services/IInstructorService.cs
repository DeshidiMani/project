using LMSCapstone.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMSCapstone.Services
{
    public interface IInstructorService
    {
        Task<CourseMaterial> UploadCourseMaterialAsync(CourseMaterial material);
        Task<IEnumerable<Progress>> GetStudentProgressAsync(int courseId);
        Task<Assignment> CreateAssignmentAsync(Assignment assignment);
        Task<AssignmentSubmission> GradeAssignmentAsync(int submissionId, double grade);
        Task DeleteCourseAsync(int courseId);
    }
}
