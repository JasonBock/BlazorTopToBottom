using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System.Text;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
public sealed class WebAssemblySiteTests 
	: PageTest
{
	[Test]
	public async Task NavigateToRootAsync()
	{
		await this.Page.GotoAsync("http://localhost:5085");
		await this.Expect(this.Page).ToHaveTitleAsync("BlazingCollatz.WebAssemblyHost");
	}

	[Test]
	public async Task NavigateToSequenceViaLinkClickAsync()
	{
		await this.Page.GotoAsync("http://localhost:5085");
		var sequenceLink = this.Page.GetByRole(AriaRole.Link, new() { Exact = true, Name = "Sequence" });
		await sequenceLink.ClickAsync();

		await this.Expect(sequenceLink).ToHaveAttributeAsync("href", "sequence");
		await this.Expect(this.Page).ToHaveURLAsync("http://localhost:5085/sequence");
	}

	[Test]
	public async Task UploadFileOnSequencePageAsync()
	{
		//this.Page.WaitForFileChooserAsync()
		await this.Page.GotoAsync("http://localhost:5085/sequence");

		await this.Page.Locator("input[type=\"file\"]").ClickAsync();

		await this.Page.Locator("input[type=\"file\"]").SetInputFilesAsync(new FilePayload
		{
			Name = "file.txt",
			MimeType = "text/plain",
			Buffer = Encoding.UTF8.GetBytes("50000"),
		});

		var sequenceValue = this.Page.Locator("input[type=\"text\"]");
		await this.Expect(sequenceValue).ToContainTextAsync("50000");
	}
}