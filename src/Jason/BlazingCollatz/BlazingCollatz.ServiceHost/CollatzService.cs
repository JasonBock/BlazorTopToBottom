using Collatz;
using CollatzGrpc;
using Google.Protobuf;
using Grpc.Core;
using Spackle;
using System.Numerics;

namespace BlazingCollatz.ServiceHost;

public sealed class CollatzService
	: CollatzServiceDefinition.CollatzServiceDefinitionBase
{
	private static (BigInteger value, int sequenceLength) FindLongestSequence(Range<int> range)
	{
		(BigInteger value, int sequenceLength) result = (BigInteger.Zero, 0);

		for (var i = range.Start; i < range.End; i++)
		{
			var sequence = CollatzSequenceGenerator.Generate(i);

			if (sequence.Length > result.sequenceLength)
			{
				result = (i, sequence.Length);
			}
		}

		return result;
	}

	public override Task<CollatzResponse> FindLongestSequence(CollatzRequest request, ServerCallContext context)
	{
		var tasks = new List<Task<(BigInteger value, int sequenceLength)>>();
		var range = new Range<int>(request.Start, request.End);
		var ranges = range.Partition(Environment.ProcessorCount);

		for (var i = 0; i < Environment.ProcessorCount; i++)
		{
			var r = ranges[i];
			tasks.Add(Task.Run(() => FindLongestSequence(r)));
		}

		Task.WaitAll(tasks.ToArray());
		(BigInteger value, int sequenceLength) result = (BigInteger.Zero, 0);

		foreach (var task in tasks)
		{
			var taskResult = task.Result;
			if (taskResult.sequenceLength > result.sequenceLength)
			{
				result = taskResult;
			}
		}

		var response = new CollatzResponse()
		{
			Value = ByteString.CopyFrom(result.value.ToByteArray()),
			Length = result.sequenceLength
		};

		return Task.FromResult(response);
	}
}