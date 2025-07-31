using System.Text.Json.Serialization;
using ScoreHub_Domain.Enums;

namespace ScoreHub_Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public Role Role { get; set; }
    
    public TeacherData? TeacherData { get; set; }
    public StudentData? StudentData { get; set; }
    public AssistantData? AssistantData { get; set; }
}