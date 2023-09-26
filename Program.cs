using System.Text.Json;
using UniversityApp.BusinessLogicLevel;
using UniversityApp.DataAccessLevel;
using UniversityApp.Models;
using UniversityApp.ViewInterface;

var university = new University(new JsonContext("teachers.json", "students.json"));

/*context.Teachers = new List<Teacher>
{
    new Teacher()
    {
        Id = Guid.NewGuid(),
        LastName = "Shubin",
        FirstName = "Yury",
        Patronymic = null,
        DateOfBirth = new DateTime(1978, 11, 13),
        Sex = Sex.Male,
        Faculty = "MATH_Faculty",
        Subjects = new List<string> { "C++", "C#"}
    }  
};*/
var teachers = university.GetAllTeachers(); 
UniversityView.ShowTeachers(teachers);
var name = CLI.InputString("Введите имя преподавателя для поиска");
var listOfTeachers = university.FindTeachersByName(name);
UniversityView.ShowTeachers(listOfTeachers);

//context.ExportTeachers();
/*foreach (var t in teachers)
{
    Console.WriteLine($"{t.Id}: {t.FullName}, {t.Faculty}, {t.Age}, {t.Sex}");
}*/
/*context.Students = new List<Student>
{
    new Student
    {
        Id = Guid.NewGuid(),
        LastName = "Ivanov",
        FirstName = "Petr",
        Patronymic = "Ilyich",
        DateOfBirth = new DateTime(1989,06,11),
        Sex = Sex.Male,
        Faculty = "MATH_Faculty",
        Marks = new List<Mark>
        {
            new()
            {
                Id = Mark.CreateId(DateTime.Now, "C++",context.Teachers[0]),
                Date = DateTime.Now,
                Subject = "C++",
                Teacher = context.Teachers[0],
                Rating = 5
            },
            new()
            {
                Id = Mark.CreateId(DateTime.Now, "C#",context.Teachers[0]),
                Date = DateTime.Now,
                Subject = "C#",
                Teacher = context.Teachers[0],
                Rating = 4 
            }
        }
    } 
};*/
/*var students = university.GetAllStudents();
foreach (var s in students)
{
    Console.WriteLine($"{s.Id}: {s.FullName}, {s.Faculty}, {s.Age}, {s.Sex}");
    foreach (var m in s.Marks)
    {
        Console.WriteLine($"\t{m.Id} ({m.Date:d}) -> {m.Subject}, {m.Teacher.FullName} ->> {m.Rating} ");
    }
}*/