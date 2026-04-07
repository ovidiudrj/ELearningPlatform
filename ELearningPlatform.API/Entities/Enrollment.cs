using System.Diagnostics;

namespace ELearningPlatform.API.Entities
{
    public class Enrollment
    {
        public int Id { get; set; }
        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;
        public int StudentId { get; set; }
        public User? Student { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
    }
}
