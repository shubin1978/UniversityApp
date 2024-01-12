using UniversityApp.DataAccessLevel.DB;

var tablePersons = new TablePersons();
var persons = tablePersons.GetAll();
foreach (var p in persons)
{
    Console.WriteLine($"{p.Id}: {p.LastName}, {p.DateOfBirth}");
}

