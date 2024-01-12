﻿using System.Text.Json;

namespace UniversityApp.DataAccessLevel.DB;

public class DbConfig
{
    public string Host { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Database { get; set; }
    public string Schema { get; set; }
    

    public override string ToString()
    {
        return $"Host={Host};Username={Username};Password={Password};Database={Database};Pooling=true;SearchPath={Schema}";
    }

    public static DbConfig? Import(string path = "D:\\Programming\\C#\\UniversityApp\\DataAccessLevel\\DB\\db_config.json ")
    {
        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<DbConfig>(json);
    }
}