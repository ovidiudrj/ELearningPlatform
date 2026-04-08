namespace ELearningPlatform.API.DTOs
{
    public class GradeCreateDto
    {
        public int EnrollmentId { get; set; } 
        public int Value { get; set; }      
    }

    public class GradeResponseDto
    {
        public int Id { get; set; }
        public int EnrollmentId { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }
    }
}