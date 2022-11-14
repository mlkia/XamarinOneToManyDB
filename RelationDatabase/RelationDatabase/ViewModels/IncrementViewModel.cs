using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RelationDatabase.ViewModels
{
    public class IncrementViewModel : BindableObject
    {
        public IncrementViewModel() 
        {
            IncreaseVMCount = new Command(OnIncrease);
        }
        public ICommand IncreaseVMCount { get; }

        int count = 0;
        string countDisplay = "Click Me!";
        public string CountVMDisplay
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
            CountVMDisplay = $"You clicked {count} time(s)!";

        }
    }
}
