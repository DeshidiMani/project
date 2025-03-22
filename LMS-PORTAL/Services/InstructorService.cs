using LMSCapstone.Models;
using LMSCapstone.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMSCapstone.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IProgressRepository _progressRepository;

        public InstructorService(
            ICourseRepository courseRepository,
            IAssignmentRepository assignmentRepository,
            IProgressRepository progressRepository)
        {
            _courseRepository = courseRepository;
            _assignmentRepository = assignmentRepository;
            _progressRepository = progressRepository;
        }

        public async Task<CourseMaterial> UploadCourseMaterialAsync(CourseMaterial material)
        {
            // Logic to upload course materials (simplified here for demo purposes)
            return new CourseMaterial
            {
                Id = 1,  // Assume auto-generated
                CourseId = material.CourseId,
                Title = material.Title,
                Description = material.Description,
                MaterialUrl = material.MaterialUrl
            };
        }

        public async Task<IEnumerable<Progress>> GetStudentProgressAsync(int courseId)
        {
            // Mock logic for retrieving progress (implement actual repository calls as needed)
            return new List<Progress>
            {
                new Progress { Id = 1, CourseId = courseId, UserId = 1, CompletionPercentage = 75.0 },
                new Progress { Id = 2, CourseId = courseId, UserId = 2, CompletionPercentage = 50.0 }
            };
        }

        public async Task<Assignment> CreateAssignmentAsync(Assignment assignment)
        {
            return await _assignmentRepository.AddAsync(assignment);
        }

        public async Task<AssignmentSubmission> GradeAssignmentAsync(int submissionId, double grade)
        {
            return await _assignmentRepository.GradeSubmissionAsync(submissionId, grade);
        }

        public async Task DeleteCourseAsync(int courseId)
        {
            await _courseRepository.DeleteAsync(courseId);
        }
    }
}
