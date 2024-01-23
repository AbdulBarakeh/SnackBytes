using System.IO;
public class SchedulingService
{
    public static SchedulingInfo MapCSV(string inputPath){
        var lines = File.ReadAllLines(inputPath);
        var mappedData = lines.ToList().Skip(1).Select(row => new SchedulingInfo{ TeacherInitials=row[0], Classname=row[1],Subject=row[2], Date=DateTime.Parse(row[3]),Classroom=row[4]});
        return mappedData;
    }
}