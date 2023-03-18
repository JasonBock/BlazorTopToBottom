using Collatz;
using System.Numerics;

var start = new BigInteger(444);
var sequence = CollatzSequenceGenerator.Generate<BigInteger>(start);

Console.WriteLine($"Starting value: {start}");
Console.WriteLine();
Console.WriteLine("Resulting sequence:");
Console.WriteLine();
Console.WriteLine(string.Join(", ", sequence));