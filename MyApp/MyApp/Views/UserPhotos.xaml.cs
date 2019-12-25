using System;
using System.Collections.Generic;
using MyApp.Models;
using MyApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPhotos : ContentPage
    {
        UserPhotosViewModel vm;

        public UserPhotos(Users users)
        {
            InitializeComponent();
            BindingContext = vm = new UserPhotosViewModel(users);
            
        }

    }
}
