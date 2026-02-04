using ScoreHub_Domain.Enums;

namespace ScoreHub_Domain.Entities.MKN;

public class LessonMkn
{
     public Guid  LessonMknId { get; set; }
     
     public int LessonMknNumber { get; set; }
     public List<double> Scores { get; set; }
     public double Score { get; set; }
     public double AdditionalCoefficient  { get; set; }
     public LessonStatus Status { get; set; }
     public bool IsStudentAttended { get; set; } 
}