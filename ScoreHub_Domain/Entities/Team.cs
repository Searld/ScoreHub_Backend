namespace ScoreHub_Domain.Entities;

public class Team
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    
    public List<StudentData> Students { get; set; }
    
    public AssistantData Assistant { get; set; }
    
    public Lesson? Lesson { get; set; } 
    public Guid? LessonId { get; set; }
}