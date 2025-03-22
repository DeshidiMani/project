using Microsoft.EntityFrameworkCore;
using LMSCapstone.Models;

namespace LMSCapstone.Data
{
    public class LMSDbContext : DbContext
    {
        public LMSDbContext(DbContextOptions<LMSDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseMaterial> CourseMaterials { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<AssignmentSubmission> AssignmentSubmissions { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Progress> Progresses { get; set; }
    }
}
