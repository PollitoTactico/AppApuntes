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
           
            await Launcher.Default.OpenAsync(apuntes.MoreInfoUrl);
        }
    }
}