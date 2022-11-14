using RelationDatabase.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RelationDatabase.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IncrementWithVM : ContentPage
    {
        public IncrementWithVM()
        {
            InitializeComponent();
            
            //---------------------------------
            
                                //BindingContext = new IncrementViewModel();

            // We can set the BindingContext ☝ directly in the XAML file. Look lines 10,11,12 att xaml file.


        }
    }
}