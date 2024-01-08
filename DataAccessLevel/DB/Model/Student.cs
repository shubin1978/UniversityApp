namespace UniversityApp.DataAccessLevel.DB.Model;

public class Student
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public int FacultyId { get; set; }
    public int Course { get; set; }
    public bool IsActive { get; set; }
}