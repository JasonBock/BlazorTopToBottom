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
	internal static int[] Generate(string start) =>
		CollatzSequenceGenerator.Generate(int.Parse(start))
			.Select(_ => (int)_).ToArray();

	[JSExport]
	internal static string FindLongestSequenceSequentially()
	{
		var stopwatch = Stopwatch.StartNew();
		var (value, sequenceLength) = CollatzInterop.FindLongestSequence(CollatzInterop.range);
		stopwatch.Stop();

		return $"Longest sequence in range {CollatzInterop.range} is {sequenceLength} for {value} - Elapsed time is {stopwatch.Elapsed}";
	}

	[JSExport]
	public static string FindLongestSequenceInParallel()
	{
		var stopwatch = Stopwatch.StartNew();
		var tasks = new List<Task<(BigInteger value, int sequenceLength)>>();
		var ranges = range.Partition(8);
		var events = new List<ManualResetEvent>();
		var threadResults = new List<(BigInteger value, int sequenceLength)>();

		foreach (var range in ranges)
		{
			var @event = new ManualResetEvent(false);

			ThreadPool.QueueUserWorkItem(
				range =>
				{
					threadResults.Add(CollatzInterop.FindLongestSequence(range));
					@event.Set();
				}, range, true);

			events.Add(@event);
		}

		WaitHandle.WaitAll(events.ToArray());

		(BigInteger value, int sequenceLength) result = (BigInteger.Zero, 0);

		foreach (var threadResult in threadResults)
		{
			if (threadResult.sequenceLength > result.sequenceLength)
			{
				result = threadResult;
			}
		}

		stopwatch.Stop();

		return $"Longest sequence in range {CollatzInterop.range} is {result.sequenceLength} for {result.value} - Elapsed time is {stopwatch.Elapsed} - processor count is {Environment.ProcessorCount}";

		/*
		for (var i = 0; i < Environment.ProcessorCount; i++)
		{
			var r = ranges[i];
			tasks.Add(Task.Run(() => FindLongestSequence(r)));
		}

#pragma warning disable CA1416 // Validate platform compatibility
		Task.WaitAll(tasks.ToArray());
#pragma warning restore CA1416 // Validate platform compatibility

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

		return $"Longest sequence in range {CollatzInterop.range} is {result.sequenceLength} for {result.value} - Elapsed time is {stopwatch.Elapsed} - processor count is {Environment.ProcessorCount}";
		*/
	}

	private static (BigInteger value, int sequenceLength) FindLongestSequence(Range<BigInteger> range)
	{
		(BigInteger value, int sequenceLength) result = (BigInteger.Zero, 0);

		for (var i = range.Start; i < range.End; i++)
		{
			var sequence = CollatzSequenceGenerator.Generate<BigInteger>(i);

			if (sequence.Length > result.sequenceLength)
			{
				result = (i, sequence.Length);
			}
		}

		return result;
	}
}