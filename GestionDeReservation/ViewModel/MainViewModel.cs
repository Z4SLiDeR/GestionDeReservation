using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace GestionDeReservation.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        string text;

        [ObservableProperty]
        ObservableCollection<string> ingredients;


        public MainViewModel()
        {
            Ingredients = new ObservableCollection<string>();
        }

        [RelayCommand]
        void AddItem()
        {
            Ingredients.Add(Text);
            Text = "";
        }
    }
}
