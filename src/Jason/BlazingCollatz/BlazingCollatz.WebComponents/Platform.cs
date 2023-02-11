using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System.Runtime.InteropServices;

namespace BlazingCollatz.WebComponents;

public sealed class Platform
	: ComponentBase
{
	protected override void BuildRenderTree(RenderTreeBuilder builder)
	{
		builder.OpenElement(0, "span");
		builder.AddContent(1, this.Value);
		builder.CloseElement();
	}

	private string Value => RuntimeInformation.OSDescription;
}