namespace UniversityApp.DataAccessLevel;

public abstract class FileContext
{
    protected readonly string PathToTeachers;
    protected readonly string PathToStudents;

    public FileContext(string pathToTeachers, string pathToStudents)
    {
        PathToTeachers = pathToTeachers;
        PathToStudents = pathToStudents;
    }
}