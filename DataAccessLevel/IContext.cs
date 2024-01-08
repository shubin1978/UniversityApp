using UniversityApp.Models;

namespace UniversityApp.DataAccessLevel;

public interface IContext
{
    public List<Teacher> Teachers { get; set; }
    public List<Student> Students { get; set; }

    public void ImportTeachers();
    public void ExportTeachers();
    
    public void ImportStudents();
    public void ExportStudents();
} 