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
using Tillsammens.WindowsPhone.WebServices.Dto;

namespace Tillsammens.WindowsPhone.App.ViewModel
{
    public class MapViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private ObservableCollection<FriendModel> _friend;
        private Geopoint _location;
        public ICommand LoadCmd { get; set; }

        public MapViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            InitializeCommands();
        }
        public ObservableCollection<FriendModel> Friend
        {
            get { return _friend; }
            set { Set(ref _friend, value); }
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
            var myBasic = new BasicGeoposition
            {
                Altitude = 0,
                Latitude = 50.2915127,
                Longitude = 18.6685934
            };

           
           

            var b = new FriendModel
            {
                Id = 2,
                Desc = "Dear friends, send me your invitations :))",
                LastVisit = DateTime.Now.Date.ToString("t"),
                Login = "Grażynka",
                PhotoUri =
                  "http://hbz.h-cdn.co/assets/16/10/980x490/landscape-1457457820-hbz-april-2016-jennifer-aniston-a-list-00-index.jpg",
                X = "50.059992",
                Y = "19.8517511",
                Geopoint = new Geopoint(new BasicGeoposition
                {
                    Altitude = 0,
                    Latitude = 50.2815127,
                    Longitude = 18.6285934
                })
            };
            Friend = new ObservableCollection<FriendModel>();
            Friend.Add(friend);
            Friend.Add(b);


        }

        public void GoBack()
        {
            _navigationService.GoBack();
        }

    }
}
