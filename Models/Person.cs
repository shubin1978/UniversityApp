namespace UniversityApp.Models;

public record Person
{
    public Guid Id{ get; init; }
    public string LastName { get; init; }
    public string FirstName { get; init; }
    public string? Patronymic { get; init; }
    public string FullName => $"{LastName} {FirstName} {Patronymic ?? ""}";
    
    public DateTime DateOfBirth { get; init; }

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
