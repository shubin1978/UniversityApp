using System.Text;

namespace UniversityApp.Models;

public record Mark
{
    public string Id { get; init; }
    public DateTime Date { get; init; }
    public string Subject { get; init; }
    public Teacher Teacher   { get; init; }
    public int Rating { get; init; }

    public static string CreateId(DateTime date, string subject, Teacher teacher)
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.Append($"{subject[0]}");
        stringBuilder.Append($"{teacher.LastName[0]}{teacher.FirstName[0]}{teacher.Patronymic?[0]}");
        stringBuilder.Append($"{date.Year}{date.Month}{date.Day}");
        var random = new Random();
        stringBuilder.Append(random.Next(1000, 10000));
         
        return stringBuilder.ToString();
    }
}