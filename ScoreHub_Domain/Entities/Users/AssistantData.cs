namespace ScoreHub_Domain.Entities;

public class AssistantData
{
    public Guid Id { get; set; }
    
    public Team Team { get; set; }
    public Guid TeamId { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }
}