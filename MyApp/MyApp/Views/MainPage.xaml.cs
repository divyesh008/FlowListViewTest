using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Models;
using MyApp.ViewModel;
using Xamarin.Forms;

namespace MyApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        HomeViewModel _homeViewModel;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = _homeViewModel = new HomeViewModel();
        }

        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedUser = e.SelectedItem as Users;
            await Navigation.PushAsync(new UserPhotos(selectedUser));
           // UsersListView.SelectedItem = null;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                UsersListView.ItemsSource = _homeViewModel.Users;
            }
            else
            {
                UsersListView.ItemsSource = _homeViewModel.Users.Where(x => x.name.ToLower().StartsWith(e.NewTextValue.ToLower()));
            }
        }
    }
}
