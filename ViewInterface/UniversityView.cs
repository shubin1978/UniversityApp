using UniversityApp.Models;

namespace UniversityApp.ViewInterface;

public static class UniversityView
{
    #region Teachers

    public static void ShowTeacher(Teacher teacher)
    {
       CLI.PrintInfo($"{teacher.Id}: {teacher.FullName}, {teacher.Faculty}, {teacher.Age}, {teacher.Sex}");
    }

    public static void ShowTeachers(List<Teacher> teachers)
    {
        foreach (var t in teachers)
        {
            ShowTeacher(t);
        }
    }

    #endregion
    
    
}