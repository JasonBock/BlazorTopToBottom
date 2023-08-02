using Bunit;
using NUnit.Framework;

namespace BlazingCollatz.WebComponents.Tests;

public static class SurveyPromptTests
{
	[Test]
	public static void Initialize()
	{
		var host = new Bunit.TestContext();
		var component = host.RenderComponent<SurveyPrompt>();
		var titleNode = component.Find("strong");
		Assert.That(titleNode.TextContent, Is.EqualTo(string.Empty));
	}

	[Test]
	public static void InitializeWithParameters()
	{
		var host = new Bunit.TestContext();
		var component = host.RenderComponent<SurveyPrompt>(
			ComponentParameter.CreateParameter("Title", "My title"));

		var titleNode = component.Find("strong");
		Assert.That(titleNode.TextContent, Is.EqualTo("My title"));
	}
}