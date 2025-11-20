namespace Portal.Layout;

public partial class MainLayout
{
    public bool _drawerOpen = true;

    public bool _isDarkMode = true;

    public static MudTheme Default = new MudTheme()
    {
        PaletteDark = new PaletteDark()
        {
            Background = "#272822",
            Surface = "#272822",
            DrawerBackground = "#272822",
            AppbarBackground = "#3E3D32",      // current line color
            Primary = "#A6E22E",              // Monokai green
            Secondary = "#66D9EF",            // Monokai cyan
            Tertiary = "#AE81FF",             // Monokai purple
            Info = "#66D9EF",
            Success = "#A6E22E",
            Warning = "#FD971F",
            Error = "#F92672",

            TextPrimary = "#F8F8F2",
            TextSecondary = "#E6DB74",        // yellow-ish highlight
            ActionDefault = "#F8F8F2",
            ActionDisabled = "#75715E",
            ActionDisabledBackground = "#3E3D32",

            Divider = "#49483E",
            DividerLight = "#75715E"
        },

        PaletteLight = new PaletteLight()
        {
            // Optional: Light mode version using Monokai colors
            Background = "#F8F8F2",
            Surface = "#F8F8F2",
            Primary = "#A6E22E",
            Secondary = "#66D9EF",
            Tertiary = "#AE81FF",

            AppbarBackground = "#E6DB74",
            DrawerBackground = "#F8F8F2",

            TextPrimary = "#272822",
            TextSecondary = "#49483E",
            Divider = "#75715E",
            DividerLight = "#3E3D32"
        },

        LayoutProperties = new LayoutProperties()
        {
            DrawerWidthLeft = "260px",
            DrawerWidthRight = "300px"
        }
    };

    public void DrawerToggle()
    {
        _drawerOpen = !_drawerOpen;
    }
}
