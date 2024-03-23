using System.IO;
using SchedulingApp.Shared.Models;
namespace SchedulingApp.Shared.Services;
public class SchedulingService
{
    public static List<SchedulingInfo> MapCSV(string inputPath)
    {
        var lines = File.ReadAllLines(inputPath);
        DateTime parsedDate;
        var mappedData = lines.ToList().Skip(1).Select(row => {
            var data = row.Split(',');
            return new SchedulingInfo{
            TeacherInitials = data[0].ToString()
            ,Classname = data[1].ToString()
            ,Subject = data[2].ToString()
            ,Date = DateTime.TryParseExact(data[3].ToString(), "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out parsedDate)?parsedDate:DateTime.Now
            ,Classroom = data[4].ToString()
            };
        });
        return mappedData.ToList();
    }
}