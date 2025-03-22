using System;
using System.Threading.Tasks;
using LMSCapstone.Models;
using LMSCapstone.Repositories;
using System.Collections.Generic;

namespace LMSCapstone.Services
{
    public interface IAssignmentService
    {
        Task<Assignment> CreateAssignmentAsync(Assignment assignment);
        Task<Assignment> GetAssignmentByIdAsync(int id);
        Task<AssignmentSubmission> SubmitAssignmentAsync(int assignmentId, AssignmentSubmission submission);
        Task<AssignmentSubmission> GradeAssignmentAsync(int submissionId, double grade);
        Task<IEnumerable<Assignment>> GetAssignmentsByCourseAsync(int courseId);
    }

    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public AssignmentService(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async Task<AssignmentSubmission> SubmitAssignmentAsync(int assignmentId, AssignmentSubmission submission)
        {
            var assignment = await _assignmentRepository.GetByIdAsync(assignmentId);
            if (assignment == null)
            {
                throw new Exception("Assignment not found");
            }
            // Auto-grade if quiz.
            if (assignment.IsQuiz)
            {
                submission.Grade = assignment.CorrectAnswer.Trim()
                    .Equals(submission.SubmissionText.Trim(), StringComparison.OrdinalIgnoreCase) ? 100 : 0;
            }
            submission.AssignmentId = assignmentId;
            return await _assignmentRepository.AddSubmissionAsync(assignmentId, submission);
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentsByCourseAsync(int courseId)
        {
            return await _assignmentRepository.GetByCourseAsync(courseId);
        }

        public async Task<Assignment> CreateAssignmentAsync(Assignment assignment)
        {
            return await _assignmentRepository.AddAsync(assignment);
        }

        public async Task<Assignment> GetAssignmentByIdAsync(int id)
        {
            return await _assignmentRepository.GetByIdAsync(id);
        }

        public async Task<AssignmentSubmission> GradeAssignmentAsync(int submissionId, double grade)
        {
            return await _assignmentRepository.GradeSubmissionAsync(submissionId, grade);
        }
    }
}
