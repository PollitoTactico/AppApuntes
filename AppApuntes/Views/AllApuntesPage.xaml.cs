using AppApuntes.Views;
using AppApuntes.Models;
using System.Reflection;


namespace AppApuntes.Views;

public partial class AllApuntesPage : ContentPage
{
    public AllApuntesPage()
    {
        InitializeComponent();

        BindingContext = new Models.AllApuntes();
    }

    protected override void OnAppearing()
    {
        ((Models.AllApuntes)BindingContext).LoadApuntes();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ApuntesPage));
    }

    private async void apuntesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var apuntes = (Models.Apuntes)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(ApuntesPage)}?{nameof(ApuntesPage.ItemId)}={apuntes.Filename}");

            // Unselect the UI
            apuntesCollection.SelectedItem = null;
        }
    }
}