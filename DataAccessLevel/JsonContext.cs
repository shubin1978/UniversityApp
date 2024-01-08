using System.Text.Encodings.Web;
using System.Text.Json;
using UniversityApp.Models;

namespace UniversityApp.DataAccessLevel;

public class JsonContext : FileContext,IContext
{
    public List<Teacher> Teachers { get; set; }
    public List<Student> Students { get; set; }

    private readonly JsonSerializerOptions _options;
     
    public JsonContext(string pathToTeachers, string pathToStudents) : base(pathToTeachers, pathToStudents)
    {
        Teachers = new List<Teacher>();
        Students = new List<Student>();

        _options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
    }
    
    public void ImportTeachers()
    {
        var teachersJson = File.ReadAllText(PathToTeachers);
        Teachers = JsonSerializer.Deserialize<List<Teacher>>(teachersJson);
    }

    public void ExportTeachers()
    {
        var teachersJson = JsonSerializer.Serialize(Teachers, _options);
        File.WriteAllText( PathToTeachers,teachersJson);

    } 
 
    public void ImportStudents()
    {
        var studentsJson = File.ReadAllText(PathToStudents);
        Students = JsonSerializer.Deserialize<List<Student>>(studentsJson);
    }

    public void ExportStudents()
    {
        var studentsJson = JsonSerializer.Serialize(Students, _options);
        File.WriteAllText(PathToStudents,studentsJson);
    }
}