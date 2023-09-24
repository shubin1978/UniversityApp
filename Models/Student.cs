namespace UniversityApp.Models;

public record Student : Person
{
    public string Faculty { get; init; }
    public List<Mark> Marks { get; init; }
}