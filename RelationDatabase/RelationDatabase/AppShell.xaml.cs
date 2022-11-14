using RelationDatabase.Views;
using Xamarin.Forms;

namespace RelationDatabase
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NoteEntryPage), typeof(NoteEntryPage));
            Routing.RegisterRoute(nameof(ArtikelEntryPage), typeof(ArtikelEntryPage));
            Routing.RegisterRoute(nameof(ArtikelViewPage), typeof(ArtikelViewPage));
            Routing.RegisterRoute(nameof(Increment), typeof(Increment));
            Routing.RegisterRoute(nameof(IncrementWithVM), typeof(IncrementWithVM));

        }
    }
}