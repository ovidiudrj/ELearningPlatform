namespace ELearningPlatform.API.DTOs
{
    public class EnrollmentCreateDto
    {
        public int StudentId { get; set; } 
        public int CourseId { get; set; }
    }

    public class EnrollmentResponseDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}