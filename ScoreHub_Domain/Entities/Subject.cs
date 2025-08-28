namespace ScoreHub_Domain.Entities;

public class Subject
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public List<Lesson>? Lessons { get; set; }
    
    public Teacher Teacher { get; set; }
    public Guid TeacherId { get; set; }
}