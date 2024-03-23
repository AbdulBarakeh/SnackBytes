using System.IO;
public class SchedulingService
{
    public static List<SchedulingInfo> MapCSV(string inputPath)
    {
        var lines = File.ReadAllLines(inputPath);
        var mappedData = lines.ToList().Skip(1).Select(row => new SchedulingInfo
        {
            TeacherInitials = row[0].ToString()
            ,Classname = row[1].ToString()
            ,Subject = row[2].ToString()
            ,Date = DateTime.Parse(row[3].ToString())
            ,Classroom = row[4].ToString()
        });
        return mappedData.ToList();
    }
}