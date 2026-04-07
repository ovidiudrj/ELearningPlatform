using System.Dynamic;

namespace ELearningPlatform.API.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description {  get; set; }
        public int TeacherId { get; set; }
        public User? Teacher {  get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        = new List<Enrollment>();
    }
}
