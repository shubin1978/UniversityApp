namespace UniversityApp.Models;

public record Mark
{
    public string Id { get; init; }
    public DateTime Date { get; init; }
    public string Subject { get; init; }
    public Teacher Te { get; init; }
    public int Rating { get; init; }
}