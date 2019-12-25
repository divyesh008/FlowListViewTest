using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;
using MyApp.Models;
using MyApp.Service;
using MyApp.Service.Implement;
using MyApp.ViewModel;
using Xamarin.Forms;

namespace MyApp.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {

        CancellationTokenSource _cts = new CancellationTokenSource();
        public Services _services = new Services();

        public HomeViewModel()
        {
            InitializeDataAsync();
        }

        private async void InitializeDataAsync()
        {
            var response = await _services.GetUsers(_cts.Token);
            if (response.Data != null) 
            {
                Users = response.Data;
            }
            else 
            {
                Error error = new Error();
                error = response.error;
                error.error_description = response.error.error_description;
            }
        }

        private List<Users> _users;
        public List<Users> Users 
        {
            get { return _users; }
            set 
            {
                _users = value;
                OnPropertyChanged("Users");
            }
        }

        //public Users Items { get; set; }

        //public HomeViewModel(Users item = null)
        //{
        //    Items = item;
        //}

        //#region Load Users List
        //public ICommand MyCommand {  set; get; }
        //private Command _loadUsersList;


        //#endregion
    }
}
