using Collatz;
using System.Numerics;
using System.Runtime.InteropServices.JavaScript;

public partial class CollatzInterop
{
	[JSExport]
	internal static int[] Generate(string start) =>
		CollatzSequenceGenerator.Generate(BigInteger.Parse(start))
			.Select(_ => (int)_).ToArray();
}
