using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RelationDatabase.Views
{

    //Use Command and ICommand instead Clicked and EnentArgs
    //in UI (xaml file) and xaml.cs file (behind Code).  

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Increment : ContentPage
    {
        public Increment()
        {
            InitializeComponent();

            IncreaseCount = new Command(OnIncrease);
            BindingContext = this;
        }

        public ICommand IncreaseCount { get; }

        int count = 0;
        string countDisplay = "Click Me!";
        public string CountDisplay 
        {
            get => countDisplay;
            set 
            {
                if (value == countDisplay)
                    return;
                
                countDisplay = value;
                OnPropertyChanged();
            }
        }
        void OnIncrease()
        {
            count++;
            CountDisplay = $"You clicked {count} time(s)!";

        }
    }
}