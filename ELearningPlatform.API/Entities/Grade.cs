namespace ELearningPlatform.API.Entities
{
    public class Grade
    {
        public int Id { get; set; }
        public int Value { get; set; } 
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public int EnrollmentId { get; set; }
        public Enrollment? Enrollment { get; set; }
    }
}
