namespace ScoreHub_Domain.Entities;

public class Team
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public List<User> Students { get; set; }
    public User Assistant { get; set; }
    
}