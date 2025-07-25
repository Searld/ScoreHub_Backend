namespace ScoreHub_Domain.Entities;

public class TeacherData
{
    public Guid Id { get; set; }
    
    public List<Subject> Subjects { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }
}