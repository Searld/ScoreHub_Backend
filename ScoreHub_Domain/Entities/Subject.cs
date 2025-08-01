﻿namespace ScoreHub_Domain.Entities;

public class Subject
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public List<Lesson> Lessons { get; set; }
    
    public Guid TeacherId { get; set; } // связь с преподом многие к одному
    public User Teacher { get; set; }
}