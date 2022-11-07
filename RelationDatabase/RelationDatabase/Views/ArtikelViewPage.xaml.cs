using RelationDatabase.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace RelationDatabase.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class ArtikelViewPage : ContentPage
    {
        public int loadNoteId { get; set; }
        public string ItemId
        {
            set
            {
                LoadArtikel(value);
                LoadNote(value);
                GetNoteId(value);
            }
        }

        public ArtikelViewPage()
        {
            InitializeComponent();
        }


        void GetNoteId(string itemId)
        {

            try
            {
                loadNoteId = Convert.ToInt32(itemId);
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load animal.");
            }
        }
        async void LoadArtikel(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                // Retrieve the note and set it as the BindingContext of the page.
                List<Artikel> artikel = await App.Database.GetrelationshipsAsync(id);
                collectionView.ItemsSource = artikel;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load note.");
            }
        }


        async void LoadNote(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                // Retrieve the note and set it as the BindingContext of the page.
                Note note = await App.Database.GetNoteAsync(id);
                BindingContext = note;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load note.");
            }
        }

        async void OnAddArtikelClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(ArtikelEntryPage)}?{nameof(ArtikelEntryPage.ItemId)}={loadNoteId.ToString()}");
        }
    }
}