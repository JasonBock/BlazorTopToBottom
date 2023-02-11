using Collatz;
using System.Numerics;

namespace BlazingCollatz.WebComponents;

public sealed class CollatzLength
{
	public CollatzLength(BigInteger start)
	{
		this.Start = start;
		this.Length = CollatzSequenceGenerator.Generate(start).Length;
	}

	public int Length { get; }
	public BigInteger Start { get; }
}
