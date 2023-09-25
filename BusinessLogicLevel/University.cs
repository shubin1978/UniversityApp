using UniversityApp.DataAccessLevel;
using UniversityApp.Models;

namespace UniversityApp.BusinessLogicLevel;

public class University
{
    private readonly IContext _context;

    public University(IContext context)
    {
        _context = context;
        _context.ImportTeachers();
        _context.ImportStudents();
    }

    #region Teachers

    public List<Teacher> GetAllTeachers() => _context.Teachers;

    public List<Teacher> FindTeachersByName(string name) => _context.Teachers.Where(t => t.FullName.Contains(name))
        .ToList();

    #endregion
    
    #region Students

    public List<Student> GetAllStudents() => _context.Students;

    #endregion
}