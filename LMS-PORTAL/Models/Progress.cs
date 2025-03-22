namespace LMSCapstone.Models
{
    public class Progress
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public double CompletionPercentage { get; set; }
    }
}
