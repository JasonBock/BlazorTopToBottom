using System.Runtime.Versioning;

// This gets around CA1416 giving a warning about using JSExportAttribute
[assembly: SupportedOSPlatform("browser")]

Console.WriteLine("BlazingCollatz.ConsoleApplication");