using System.Text.Json.Serialization;

namespace UniversityApp.Models;

public record Person
{
    public Guid Id{ get; init; }
    public string LastName { get; init; }
    public string FirstName { get; init; }
    public string? Patronymic { get; init; }
    [JsonIgnore]
    public string FullName => $"{LastName} {FirstName} {Patronymic ?? ""}";
    
    public DateTime DateOfBirth { get; init; }
    [JsonIgnore]
    public int Age
    {
        get
        {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }
    }

    public Sex Sex { get; init; }
};
