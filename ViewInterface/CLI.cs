namespace UniversityApp.ViewInterface;

public static class CLI
{
    private static void Print(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(message);
        Console.ResetColor();
    }
    
    private static void PrintLine(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void PrintInfo(string message)
    {
        PrintLine(message, ConsoleColor.Blue);
    }

    public static string InputString(string message)
    {
        Print(message, ConsoleColor.Yellow);
        return Console.ReadLine();
    }
}