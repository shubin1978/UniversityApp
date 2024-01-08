namespace UniversityApp.Models;

public record Teacher()  : Person
{
    public string Faculty { get; init; }
    public List<string> Subjects { get; init; }
}