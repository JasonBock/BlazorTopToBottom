using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
public sealed class WebAssemblySiteTests 
	: PageTest
{
	[Test]
	public async Task NavigateToSequenceAsync()
	{
		await this.Page.GotoAsync("http://localhost:5085");

		await this.Expect(this.Page).ToHaveTitleAsync("BlazingCollatz.WebAssemblyHost");

		var sequenceLink = this.Page.GetByRole(AriaRole.Link, new() { Exact = true, Name = "Sequence" });
		await sequenceLink.ClickAsync();

		await this.Expect(sequenceLink).ToHaveAttributeAsync("href", "sequence");
		await this.Expect(this.Page).ToHaveURLAsync("http://localhost:5085/sequence");
	}
}