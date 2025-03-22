namespace LMSCapstone.Models
{
    public class CourseMaterial
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string MaterialUrl { get; set; }
    }
}
