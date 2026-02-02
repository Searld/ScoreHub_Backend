namespace LessonMkn.Entities;

public class LessonMkn
{
     public Guid  LessonMknId { get; set; }
     
     public int LessonMknNumber { get; set; }
     public List<double> Scores { get; set; }
     public double Score { get; set; }
     public double AdditionalCoefficient  { get; set; }
}