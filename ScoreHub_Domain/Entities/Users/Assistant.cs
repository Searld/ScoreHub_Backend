namespace ScoreHub_Domain.Entities;

public class Assistant : User
{
    public Team? Team { get; set; }
    public Guid? TeamId { get; set; }
}