using Collatz;
using System.Runtime.InteropServices.JavaScript;

public partial class CollatzInterop
{
	[JSExport]
	internal static int[] Generate(string start) =>
		CollatzSequenceGenerator.Generate(int.Parse(start))
			.ToArray();
}
