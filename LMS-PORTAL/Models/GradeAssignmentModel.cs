using System.ComponentModel.DataAnnotations;

namespace LMSCapstone.Models
{
    public class GradeAssignmentModel
    {
        [Required]
        public int SubmissionId { get; set; }
        
        [Required]
        public double Grade { get; set; }
    }
}
