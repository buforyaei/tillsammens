using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Devices.Geolocation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Tillsammens.WindowsPhone.WebServices.Dto;

namespace Tillsammens.WindowsPhone.App.ViewModel
{
    public class MapViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private FriendModel _friend;
        private Geolocator _location;
        public ICommand LoadCmd { get; set; }

        public MapViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            InitializeCommands();
        }
        public FriendModel Friend
        {
            get { return _friend; }
            set { Set(ref _friend, value); }
        }
        public Geolocator Location
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
            Friend = friend;
            
        }

        public void GoBack()
        {
            _navigationService.GoBack();
        }

    }
}
