using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Devices.Geolocation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Tillsammens.WindowsPhone.Domain.Services;
using Tillsammens.WindowsPhone.Domain.Services.Interfaces;
using Tillsammens.WindowsPhone.WebServices.Dto;

namespace Tillsammens.WindowsPhone.App.ViewModel
{
    public class MapViewModel : TillsammensViewModelBase
    {
        private readonly INavigationService _navigationService;
        private ObservableCollection<FriendModel> _friends;
        private Geopoint _location;
        public ICommand LoadCmd { get; set; }

        public MapViewModel
            (INavigationService navigationService, 
            ITillsammensService tillsammensService, 
            IDialogService dialogService)
            :base(dialogService,tillsammensService)

        {
            _navigationService = navigationService;
            InitializeCommands();
        }
        public ObservableCollection<FriendModel> Friends
        {
            get { return _friends; }
            set { Set(ref _friends, value); }
        }
        public Geopoint Location
        {
            get { return _location; }
            set { Set(ref _location, value); }
        }
        private void InitializeCommands()
        {
            LoadCmd = new RelayCommand<FriendModel>(Load);
        }

        private void Load(FriendModel friend)
        {
            IsWorking = true;
            var friends = new ObservableCollection<FriendModel>();
            foreach (var f in AppSession.Current.FriendsList)
            {
                f.Geopoint = new Geopoint
                    (new BasicGeoposition
                    {
                        Latitude = f.X,
                        Longitude = f.Y,
                        Altitude = 0
                    });

                if (f.X != 0 && f.Y != 0)
                {
                    if (f.Login != friend.Login)
                    {
                        friends.Add(f);
                    }
                    else friends.Insert(0, f);
                }
            }
            Friends = friends;
            IsWorking = false;
        }

        public void GoBack()
        {
            _navigationService.GoBack();
        }

    }
}
