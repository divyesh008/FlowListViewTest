using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using MyApp.Models;
using MyApp.Service.Implement;
using Xamarin.Forms;

namespace MyApp.ViewModel
{
    public class UserPhotosViewModel : BaseViewModel
    {
        public int userId;
        CancellationTokenSource _cts = new CancellationTokenSource();
        public Services _services = new Services();

        private Users _user;
        public Users user
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged("user");
            }
        }

        public UserPhotosViewModel(Users user)
        {
            _user = user;
            InitializeDataAsync(user.id);
        }

        private async void InitializeDataAsync(int id)
        {
            userId = id;
            var response = await _services.GetAlbums(user.id, _cts.Token);
            if (response.Data != null)
            {
                if (response.Data.Count > 0)
                {
                    userAlbumsList = response.Data;
                }
            }
            else
            {
                Error error = new Error();
                error = response.error;
                error.error_description = response.error.error_description;
            }
        }
        
        private List<UserAlbums> _userAlbumsList;
        public List<UserAlbums> userAlbumsList
        {
            get{ return _userAlbumsList; }
            set
            {
                _userAlbumsList = value;
                OnPropertyChanged("userAlbumsList");
            }
        }

        public Command ItemTappedCommand
        {
            get
            {
                return new Command((data) =>
                {
                    var item = data as UserAlbums;
                    //App.Current.MainPage.Navigation.PushAsync(new DisplayPhotos(item.id));
                });
            }
        }
    }
}
