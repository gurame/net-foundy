namespace NetFoundy.Concepts;

class Enums
{
    [Flags]
    public enum Permissions
    {
        None = 0,
        Read = 1,
        Write = 2,
        Execute = 4,
    }
    public static void Run()
    {
        Permissions readWrite = Permissions.Read | Permissions.Write;
        Console.WriteLine(readWrite);

        bool canRead = (readWrite & Permissions.Read) == Permissions.Read;
        bool canWrite = (readWrite & Permissions.Write) == Permissions.Write;
        bool canExecute = (readWrite & Permissions.Execute) == Permissions.Execute;
        Console.WriteLine($"Can read: {canRead}");
        Console.WriteLine($"Can write: {canWrite}");
        Console.WriteLine($"Can execute: {canExecute}");
    }
}