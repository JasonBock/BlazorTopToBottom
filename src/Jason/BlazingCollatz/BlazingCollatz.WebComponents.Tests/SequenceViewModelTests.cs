using BlazingCollatz.WebComponents;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Rocks;

namespace BlazingCollatz.WebComponents.Tests;

public static class SequenceViewModelTests
{
	[Test]
	public static void Create()
	{
		var viewModel = new SequenceViewModel(Rock.Make<IJSRuntime>().Instance());
		Assert.Multiple(() =>
		{
			Assert.That(viewModel.ChartReference, Is.EqualTo(default(ElementReference)), nameof(viewModel.Changed));
			Assert.That(viewModel.CurrentSequence, Is.EqualTo(string.Empty), nameof(viewModel.CurrentSequence));
			Assert.That(viewModel.Labels, Is.EqualTo(Array.Empty<string>()), nameof(viewModel.Labels));
			Assert.That(viewModel.Sequence, Is.EqualTo(Array.Empty<int>()), nameof(viewModel.Sequence));
			Assert.That(viewModel.Value, Is.Null, nameof(viewModel.Value));
		});
	}

	[Test]
	public static void CreateWithNullRuntime() =>
		Assert.That(() => new SequenceViewModel(null!), Throws.TypeOf<ArgumentNullException>());

	[Test]
	public static async Task CreateSequenceAsync()
	{
		var reference = Rock.Create<IJSObjectReference>();
		reference.Methods().InvokeAsync<object>(Constants.ChartsMethod, Arg.Any<object?[]?>())
			.Returns(new ValueTask<object>());

		var runtime = Rock.Create<IJSRuntime>();
		runtime.Methods().InvokeAsync<IJSObjectReference>(Constants.Import, new object[] { Constants.ChartsFileLocation })
			.Returns(new ValueTask<IJSObjectReference>(reference.Instance()));

		var wasChangedRaised = false;

		var viewModel = new SequenceViewModel(runtime.Instance())
		{
			Value = "5"
		};
		viewModel.Changed += (s, e) => wasChangedRaised = true;

		await viewModel.CreateSequenceAsync();
		Assert.Multiple(() =>
		{
			Assert.That(viewModel.CurrentSequence, Is.EqualTo("5, 8, 4, 2, 1"), nameof(viewModel.CurrentSequence));
			Assert.That(viewModel.Sequence, Is.EquivalentTo(new int[] { 5, 8, 4, 2, 1 }), nameof(viewModel.Sequence));
			Assert.That(viewModel.Labels, Is.EquivalentTo(new[] { "1", "2", "3", "4", "5" }), nameof(viewModel.Labels));
			Assert.That(wasChangedRaised, Is.True, nameof(wasChangedRaised));
		});

		runtime.Verify();
		reference.Verify();
	}

	[Test]
	public static async Task CreateSequenceWhenValueIsIncorrectAsync()
	{
		var reference = Rock.Create<IJSObjectReference>();
		reference.Methods().InvokeAsync<object>(Constants.ChartsMethod, Arg.Any<object?[]?>())
			.Returns(new ValueTask<object>());

		var runtime = Rock.Create<IJSRuntime>();
		runtime.Methods().InvokeAsync<IJSObjectReference>(Constants.Import, new object[] { Constants.ChartsFileLocation })
			.Returns(new ValueTask<IJSObjectReference>(reference.Instance()));

		var wasChangedRaised = false;

		var viewModel = new SequenceViewModel(runtime.Instance())
		{
			Value = "-5"
		};
		viewModel.Changed += (s, e) => wasChangedRaised = true;

		await viewModel.CreateSequenceAsync();
		Assert.Multiple(() =>
		{
			Assert.That(viewModel.CurrentSequence, Is.EqualTo("The value, -5, is incorrect."), nameof(viewModel.CurrentSequence));
			Assert.That(viewModel.Sequence, Is.EqualTo(Array.Empty<int>()), nameof(viewModel.Sequence));
			Assert.That(viewModel.Labels, Is.EqualTo(Array.Empty<string>()), nameof(viewModel.Labels));
			Assert.That(wasChangedRaised, Is.True, nameof(wasChangedRaised));
		});

		runtime.Verify();
	}

	[Test]
	public static async Task CreateSequenceWhenValueIsNotABigIntegerAsync()
	{
		var reference = Rock.Create<IJSObjectReference>();
		reference.Methods().InvokeAsync<object>(Constants.ChartsMethod, Arg.Any<object?[]?>())
			.Returns(new ValueTask<object>());

		var runtime = Rock.Create<IJSRuntime>();
		runtime.Methods().InvokeAsync<IJSObjectReference>(Constants.Import, new object[] { Constants.ChartsFileLocation })
			.Returns(new ValueTask<IJSObjectReference>(reference.Instance()));

		var wasChangedRaised = false;

		var viewModel = new SequenceViewModel(runtime.Instance())
		{
			Value = "quux"
		};
		viewModel.Changed += (s, e) => wasChangedRaised = true;

		await viewModel.CreateSequenceAsync();
		Assert.Multiple(() =>
		{
			Assert.That(viewModel.CurrentSequence, Is.EqualTo("quux is not a valid integer."), nameof(viewModel.CurrentSequence));
			Assert.That(viewModel.Sequence, Is.EqualTo(Array.Empty<int>()), nameof(viewModel.Sequence));
			Assert.That(viewModel.Labels, Is.EqualTo(Array.Empty<string>()), nameof(viewModel.Labels));
			Assert.That(wasChangedRaised, Is.True, nameof(wasChangedRaised));
		});

		runtime.Verify();
	}
}