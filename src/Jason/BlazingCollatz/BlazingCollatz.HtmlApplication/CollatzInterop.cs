using Collatz;
using Spackle;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

[assembly: SupportedOSPlatform("browser")]

public partial class CollatzInterop
{
	private static readonly Range<BigInteger> range = new(new BigInteger(250_000), new BigInteger(300_000));

	[JSExport]
	internal static int[] Generate(string start)
	{
		Console.WriteLine("CollatzInterop.Generated() - invoked.");
		var result = CollatzSequenceGenerator.Generate(int.Parse(start))
			 .ToArray();
		Console.WriteLine("CollatzInterop.Generated() - finished.");
		return result;
	}

	[JSExport]
	internal static string FindLongestSequenceSequentially()
	{
		Console.WriteLine("CollatzInterop.FindLongestSequenceSequentially() - invoked.");
		var stopwatch = Stopwatch.StartNew();
		var (value, sequenceLength) = CollatzInterop.FindLongestSequence(CollatzInterop.range);
		stopwatch.Stop();

		Console.WriteLine("CollatzInterop.FindLongestSequenceSequentially() - finished.");
		return $"Longest sequence in range {CollatzInterop.range} is {sequenceLength} for {value} - Elapsed time is {stopwatch.Elapsed}";
	}

	[JSExport]
	public static async Task<string> FindLongestSequenceInParallelUsingTasksAsync()
	{
		Console.WriteLine("CollatzInterop.FindLongestSequenceInParallelUsingTasksAsync() - invoked.");

		var stopwatch = Stopwatch.StartNew();
		var ranges = range.Partition(8);
		var tasks = new List<Task<(BigInteger value, int sequenceLength)>>();

		Console.WriteLine("CollatzInterop.FindLongestSequenceInParallelUsingTasksAsync() - creating partitions.");

		for (var i = 0; i < ranges.Length; i++)
		{
			var range = ranges[i];
			tasks.Add(Task.Run(() => FindLongestSequence(range)));
		}

		Console.WriteLine("CollatzInterop.FindLongestSequenceInParallelUsingTasksAsync() - awaiting.");

		await Task.WhenAll(tasks);

		Console.WriteLine("CollatzInterop.FindLongestSequenceInParallelUsingTasksAsync() - finishing.");

		(BigInteger value, int sequenceLength) result = (BigInteger.Zero, 0);

		foreach (var task in tasks)
		{
			var taskResult = task.Result;
			if (taskResult.sequenceLength > result.sequenceLength)
			{
				result = taskResult;
			}
		}

		stopwatch.Stop();

		Console.WriteLine("CollatzInterop.FindLongestSequenceInParallelUsingTasksAsync() - finished.");

		return $"Longest sequence in range {CollatzInterop.range} is {result.sequenceLength} for {result.value} - Elapsed time is {stopwatch.Elapsed} - processor count is {Environment.ProcessorCount}";
	}

	private static (BigInteger value, int sequenceLength) FindLongestSequence(Range<BigInteger> range)
	{
		Console.WriteLine($"CollatzInterop.FindLongestSequence() - invoked with {range}.");

		(BigInteger value, int sequenceLength) result = (BigInteger.Zero, 0);

		for (var i = range.Start; i < range.End; i++)
		{
			var sequence = CollatzSequenceGenerator.Generate<BigInteger>(i);

			if (sequence.Length > result.sequenceLength)
			{
				result = (i, sequence.Length);
			}
		}

		Console.WriteLine($"CollatzInterop.FindLongestSequence() - finished.");

		return result;
	}
}