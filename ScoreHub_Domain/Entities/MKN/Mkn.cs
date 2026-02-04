namespace ScoreHub_Domain.Entities.MKN;

public class Mkn
{
    public Guid MknId { get; set; }
    
    public double RawScores { get; set; }
    public double FirstModuleScores { get; set; }
    public double SecondModuleScores { get; set; }
    public double ThirdModuleScores { get; set; }
    public double FinalScores { get; set; }
    public double RawMark { get; set; }
    public double FinalMark { get; set; }

    public List<LessonMkn> Lessons { get; set; } = new();
}