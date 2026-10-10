namespace ShopApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
    }

    private async void MenuItem_Clicked(object sender, EventArgs e)
    {
        await Launcher.Default.OpenAsync("https://github.com/Xnaughty/BigBountyTips");
    }
}