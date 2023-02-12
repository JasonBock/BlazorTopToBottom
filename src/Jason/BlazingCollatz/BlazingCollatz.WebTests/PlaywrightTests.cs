using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class PlaywrightTests : PageTest
{
	[Test]
	public async Task HomepageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntroPageAsync()
	{
		await this.Page.GotoAsync("https://playwright.dev");

		// Expect a title "to contain" a substring.
		await this.Expect(this.Page).ToHaveTitleAsync(new Regex("Playwright"));

		// create a locator
		var getStarted = this.Page.GetByRole(AriaRole.Link, new() { Name = "Get started" });

		// Expect an attribute "to be strictly equal" to the value.
		await this.Expect(getStarted).ToHaveAttributeAsync("href", "/docs/intro");

		// Click the get started link.
		await getStarted.ClickAsync();

		// Expects the URL to contain intro.
		await this.Expect(this.Page).ToHaveURLAsync(new Regex(".*intro"));
	}
}