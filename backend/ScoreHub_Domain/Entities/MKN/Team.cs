namespace ScoreHub_Domain.Entities.MKN;

public class Team
{
    public Guid Id { get; set; }
    public int TeamNumber { get; set; }
    public List<Guid> Members { get; set; } = new List<Guid>();
    public Guid AssistantId { get; set; }
    

}