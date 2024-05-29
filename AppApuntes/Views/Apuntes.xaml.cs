namespace AppApuntes.Views;

public partial class Apuntes : ContentPage
{
	public Apuntes()
	{
		InitializeComponent();
	}
  

    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.ApuntesA apuntes)
        {
            // Navigate to the specified URL in the system browser.
            await Launcher.Default.OpenAsync(apuntes.MoreInfoUrl);
        }
    }
}