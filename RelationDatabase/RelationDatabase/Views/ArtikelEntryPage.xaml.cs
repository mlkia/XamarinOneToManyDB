using System;
using System.IO;
using RelationDatabase.Models;
using RelationDatabase;
using Xamarin.Forms;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices.ComTypes;

namespace RelationDatabase.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class ArtikelEntryPage : ContentPage
    {

        public int loadId { get; set; }
        public string ItemId
        {
            set
            {
                //LoadArtikel(value);
                LoadAnimal(value);
            }
        }

        public ArtikelEntryPage()
        {
            InitializeComponent();

            // Set the BindingContext of the page to a new Artikel.
            BindingContext = new Artikel();
        }

        void LoadAnimal(string itemId)
        {

            try
            {
                loadId = Convert.ToInt32(itemId);
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load animal.");
            }
        }

        /*async void LoadArtikel(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                // Retrieve the note and set it as the BindingContext of the page.
                Artikel artikel = await App.Database.GetArtikelAsync(id);
                BindingContext = artikel;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load note.");
            }
        }*/

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var artikel = (Artikel)BindingContext;
            artikel.NoteId = loadId;
            if (!string.IsNullOrWhiteSpace(artikel.Text))
            {
                await App.Database.SaveArticlelAsync(artikel);
            }

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }

    }
}