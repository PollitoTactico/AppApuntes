namespace AppApuntes.Views;
[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class ApuntesPage : ContentPage
{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

    public ApuntesPage()
    {
        InitializeComponent();
        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        LoadNote(Path.Combine(appDataPath, randomFileName));
        if (File.Exists(_fileName))
            TextEditor.Text = File.ReadAllText(_fileName);
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Apuntes apunte)
            File.WriteAllText(apunte.Filename, TextEditor.Text);

        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Apuntes apunte)
        {
            // Delete the file.
            if (File.Exists(apunte.Filename))
                File.Delete(apunte.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }
    private void LoadNote(string fileName)
    {
        Models.Apuntes apuntesModel = new Models.Apuntes();
        apuntesModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            apuntesModel.Date = File.GetCreationTime(fileName);
            apuntesModel.Text = File.ReadAllText(fileName);
        }

        BindingContext = apuntesModel;
    }
    public string ItemId
    {
        set { LoadNote(value); }
    }


}