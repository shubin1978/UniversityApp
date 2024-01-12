using System.Data;
using Npgsql;
using UniversityApp.DataAccessLevel.DB.Model;

namespace UniversityApp.DataAccessLevel.DB;

public class TablePersons : ICrud<Person>
{

    private NpgsqlConnection _db;
    private NpgsqlCommand _command;
    
    public TablePersons()
    {
        var connectionString = DbConfig.Import().ToString();
        _db = new NpgsqlConnection(connectionString);
        _command = new NpgsqlCommand()
        {
            Connection = _db
        };
    }
    
    public bool Insert(Person obj)
    {
        throw new NotImplementedException();  
    }

    public bool Update(Person obj)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Person obj)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Person>? GetAll()
    {
        _db.Open();

        var sql = "SELECT * FROM table_persons";
        _command.CommandText = sql;
        var result = _command.ExecuteReader();
        if (!result.HasRows)
        {
            _db.Close();
            return null;
        }

        var persons = new List<Person>();
        while (result.Read())
        {
            persons.Add(new Person()
            {
                Id = result.GetInt32("id"),
                LastName = result.GetString("last_name"),
                FirstName = result.GetString("first_name"),
                Patronymic = result.GetString("patronymic"),
                DateOfBirth = result.GetDateTime("date_of_birth")
            });
        }
        _db.Close();

        return persons;
    }

    public Person? GetById(int id)
    {
        throw new NotImplementedException();
    }
}