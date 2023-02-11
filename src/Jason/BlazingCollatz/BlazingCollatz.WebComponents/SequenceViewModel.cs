using Collatz;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Numerics;

namespace BlazingCollatz.WebComponents
{
	public sealed class SequenceViewModel
	{
		private readonly IJSRuntime runtime;

		public SequenceViewModel(IJSRuntime runtime) =>
			this.runtime = runtime ?? throw new ArgumentNullException(nameof(runtime));

		public async Task CreateSequenceAsync()
		{
			var module = await this.runtime.InvokeAsync<IJSObjectReference>(
				Constants.Import, Constants.ChartsFileLocation);

			if (BigInteger.TryParse(this.Value, out var value))
			{
				try
				{
					var sequence = CollatzSequenceGenerator.Generate(value);
					this.CurrentSequence = string.Join(", ", sequence);
					this.Sequence = sequence.Select(_ => (int)_).ToArray();
					this.Labels = Enumerable.Range(1, sequence.Length).Select(_ => _.ToString()).ToArray();
					await module.InvokeAsync<object>(
						Constants.ChartsMethod, this.ChartReference,
						sequence.Select(_ => (int)_).ToArray(), this.Labels);
				}
				catch (ArgumentException)
				{
					this.CurrentSequence = $"The value, {value}, is incorrect.";
					this.Sequence = Array.Empty<int>();
					this.Labels = Array.Empty<string>();
					await module.InvokeAsync<object>(
						Constants.ChartsMethod, this.ChartReference,
						Array.Empty<int>(), Array.Empty<string>());
				}
			}
			else
			{
				this.CurrentSequence = $"{this.Value} is not a valid integer.";
				this.Sequence = Array.Empty<int>();
				this.Labels = Array.Empty<string>();
				await module.InvokeAsync<object>(
					Constants.ChartsMethod, this.ChartReference,
					Array.Empty<int>(), Array.Empty<string>());
			}

			this.Changed?.Invoke(this, EventArgs.Empty);
		}

		public ElementReference ChartReference { get; set; }
		public string CurrentSequence { get; private set; } = string.Empty;
		public string[] Labels { get; private set; } = Array.Empty<string>();
		public int[] Sequence { get; private set; } = Array.Empty<int>();
		public string? Value { get; set; }

		public event EventHandler? Changed;
	}
}