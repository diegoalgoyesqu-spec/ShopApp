namespace ShopApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(
            nameof(ShopApp.Views.HelpSupportDetailPage),
            typeof(ShopApp.Views.HelpSupportDetailPage));
    }

    private async void MenuItem_Clicked(object sender, EventArgs e)
    {
        await Launcher.Default.OpenAsync("https://github.com/Xnaughty/BigBountyTips");
    }
}
