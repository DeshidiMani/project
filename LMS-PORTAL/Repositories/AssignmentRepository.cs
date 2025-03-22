using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMSCapstone.Models;
using LMSCapstone.Data;
using Microsoft.EntityFrameworkCore;

namespace LMSCapstone.Repositories
{
    // public interface IAssignmentRepository
    // {
    //     Task<Assignment> AddAsync(Assignment assignment);
    //     Task<Assignment> GetByIdAsync(int id);
    //     Task<IEnumerable<Assignment>> GetByCourseAsync(int courseId);
    //     Task<AssignmentSubmission> AddSubmissionAsync(int assignmentId, AssignmentSubmission submission);
    //     Task<AssignmentSubmission> GradeSubmissionAsync(int submissionId, double grade);
    // }

    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly LMSDbContext _context;
        public AssignmentRepository(LMSDbContext context)
        {
            _context = context;
        }
        
        public async Task<Assignment> AddAsync(Assignment assignment)
        {
            await _context.Assignments.AddAsync(assignment);
            await _context.SaveChangesAsync();
            return assignment;
        }
        
        public async Task<Assignment> GetByIdAsync(int id)
        {
            return await _context.Assignments.FindAsync(id);
        }

        public async Task<IEnumerable<Assignment>> GetByCourseAsync(int courseId)
        {
            return await _context.Assignments
                .Where(a => a.CourseId == courseId)
                .ToListAsync();
        }
        
        public async Task<AssignmentSubmission> AddSubmissionAsync(int assignmentId, AssignmentSubmission submission)
        {
            submission.AssignmentId = assignmentId;
            await _context.AssignmentSubmissions.AddAsync(submission);
            await _context.SaveChangesAsync();
            return submission;
        }
        
        public async Task<AssignmentSubmission> GradeSubmissionAsync(int submissionId, double grade)
        {
            var submission = await _context.AssignmentSubmissions.FindAsync(submissionId);
            if (submission == null) return null;
            submission.Grade = grade;
            _context.AssignmentSubmissions.Update(submission);
            await _context.SaveChangesAsync();
            return submission;
        }
    }
}
