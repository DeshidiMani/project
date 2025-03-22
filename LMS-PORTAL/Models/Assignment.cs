using System;
using System.ComponentModel.DataAnnotations;

namespace LMSCapstone.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        
        // If true, this assignment is a quiz that gets auto-graded.
        public bool IsQuiz { get; set; }
        public string CorrectAnswer { get; set; }
    }

    public class AssignmentSubmission
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public int StudentId { get; set; }
        public string SubmissionText { get; set; }
        public DateTime SubmittedAt { get; set; }
        public double? Grade { get; set; }
    }
}
