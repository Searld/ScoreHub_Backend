using ScoreHub_Domain.Entities.MKN;

namespace ScoreHub_Domain.Entities;

public class Student
{
    public Guid StudentId { get; set; }
    
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? Patronymic { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    
    public Mkn? Mkn { get; set; }
    public Guid? MknId { get; set; }
}