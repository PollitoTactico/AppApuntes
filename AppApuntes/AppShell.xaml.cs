namespace AppApuntes
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Views.ApuntesPage), typeof(Views.ApuntesPage));
        }
    }
}
