using ScoreHub_Domain.Enums;
 
 namespace ScoreHub_Domain.Entities;
 
 public class Lesson
 {
     public Guid Id { get; set; }
     public string Name { get; set; }
     
     public LessonStatus Status { get; set; }
     
     public DateTime StartAt { get; set; }
     
     public bool IsCommandLesson { get; set; }
     
     public List<Team>? Teams { get; set; }
     
     public List<Student>? Students { get; set; }
     
     public Subject Subject { get; set; } 
     public Guid SubjectId { get; set; }
 }