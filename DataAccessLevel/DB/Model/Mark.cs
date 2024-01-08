namespace UniversityApp.DataAccessLevel.DB.Model;

public class Mark
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int Rating { get; set; }
    public int SubjectId { get; set; }
    public int TeacherId { get; set; }
}