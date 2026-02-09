using ScoreHub_Domain.Enums;

namespace ScoreHub_Domain.Entities.MKN;

public class LessonMkn
{
     public Guid Id { get; set; }
     
     public int LessonNumber { get; set; }
     public List<LessonScore> Scores { get; set; }
     public double Score { get; set; }
     public double AdditionalCoefficient  { get; set; }
     public LessonStatus Status { get; set; } 
     public bool IsStudentAttended { get; set; } 
     public string? ReasonForAbsence  { get; set; }
     
     public Team Team { get; set; }
     public Guid TeamId { get; set; }
}