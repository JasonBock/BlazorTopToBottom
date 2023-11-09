// This gets around CA1416 giving a warning about using JSExportAttribute
using System.Runtime.Versioning;

[assembly: SupportedOSPlatform("browser")]

Console.WriteLine("BlazingCollatz.HtmlApplication");