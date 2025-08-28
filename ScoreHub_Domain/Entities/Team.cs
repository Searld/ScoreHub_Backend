namespace ScoreHub_Domain.Entities;

public class Team
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    
    public List<Student> Students { get; set; }
    
    public Assistant Assistant { get; set; }
    
    public Lesson? Lesson { get; set; } 
    public Guid? LessonId { get; set; }
}