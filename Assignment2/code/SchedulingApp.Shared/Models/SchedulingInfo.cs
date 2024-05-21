namespace SchedulingApp.Shared.Models;
public record SchedulingInfo
{
    public Guid Guid { get; set; } = Guid.NewGuid();
    public string TeacherInitials {get; set;}
    public string Classname { get; set; }
    public string Subject { get; set; }
    public DateTime Date { get; set; }
    public string Classroom {get; set;}
}