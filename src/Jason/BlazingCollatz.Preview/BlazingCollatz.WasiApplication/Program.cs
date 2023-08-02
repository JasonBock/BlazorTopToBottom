using Collatz;
using System.Numerics;

// Remember to run:
//
// wasmtime --dir=. BlazingCollatz.WasiApplication.wasm
//
// to "see" this file
if (File.Exists("value.txt"))
{
	if (BigInteger.TryParse(File.ReadAllText("value.txt"), out var start))
	{
		var sequence = CollatzSequenceGenerator.Generate<BigInteger>(start);

		Console.WriteLine($"Starting value: {start}");
		Console.WriteLine();
		Console.WriteLine("Resulting sequence:");
		Console.WriteLine();
		Console.WriteLine(string.Join(", ", sequence));
	}
	else
	{
		Console.WriteLine("Could not parse content in value.txt");
	}
}
else
{
	var start = new BigInteger(444);
	var sequence = CollatzSequenceGenerator.Generate<BigInteger>(start);

	Console.WriteLine($"Starting value: {start}");
	Console.WriteLine();
	Console.WriteLine("Resulting sequence:");
	Console.WriteLine();
	Console.WriteLine(string.Join(", ", sequence));
}