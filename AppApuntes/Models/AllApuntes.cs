using System.Collections.ObjectModel;

namespace AppApuntes.Models;

internal class AllApuntes
{
    public ObservableCollection<Apuntes> Apuntes { get; set; } = new ObservableCollection<Apuntes>();

    public AllApuntes() =>
        LoadApuntes();

    public void LoadApuntes()
    {
        Apuntes.Clear();

        string appDataPath = FileSystem.AppDataDirectory;

        IEnumerable<Apuntes> apuntes = Directory
                                    .EnumerateFiles(appDataPath, "*.notes.txt")
                                    .Select(filename => new Apuntes()
                                    {
                                        Filename = filename,
                                        Text = File.ReadAllText(filename),
                                        Date = File.GetLastWriteTime(filename)
                                    })
                                    .OrderBy(apuntes => apuntes.Date);

        foreach (Apuntes apuntesA in apuntes)
            Apuntes.Add(apuntesA);
    }
}

  
