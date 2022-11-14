using MvvmHelpers.Commands;
using System;
using MvvmHelpers;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace RelationDatabase.ViewModels
{
    public class IncrementViewModel : ObservableObject
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

            //Optionally you can use this 👇 instead of the above, but you need first install MvvmHelpers Nuget packages. You nedd also change BindableObject to ObservableObject.
            //set => SetProperty(ref countDisplay, value);
        }
        void OnIncrease()
        {
            count++;
            CountVMDisplay = $"You clicked {count} time(s)!";

        }
    }
}
