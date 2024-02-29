
namespace EngineAnalyticsWebApp.UI.Components.Layout
{
    public partial class NavMenu
    {
        private bool collapseNavMenu = true;

        // private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;
        private string? NavMenuCssClass => collapseNavMenu ? "sidebar-collapse" : null;

        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }
    }
}
