using System.ComponentModel.DataAnnotations;

namespace LMSCapstone.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}
