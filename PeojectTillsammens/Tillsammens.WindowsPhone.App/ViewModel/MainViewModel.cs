using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Tillsammens.WindowsPhone.Domain.Services;
using Tillsammens.WindowsPhone.WebServices.Dto;

namespace Tillsammens.WindowsPhone.App.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private IEnumerable<FriendModel> _friends;
        private IEnumerable<SearchedUser> _searchedUsers;
        private string _profileUri;
        private string _profileLogin;
        private string _profileDescription;
        private string _profileLastVisit;
        public ICommand LoadCmd { get; set; }
        public ICommand GoToSettingsCmd { get; set; }

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            InitializeCommands();
        }
        public string ProfileUri
        {
            get { return _profileUri; }
            set { Set(ref _profileUri, value); }
        }
        public string ProfileLogin
        {
            get { return _profileLogin; }
            set { Set(ref _profileLogin, value); }
        }
        public string ProfileDescription
        {
            get { return _profileDescription; }
            set { Set(ref _profileDescription, value); }
        }
        public string ProfileLastVisit
        {
            get { return _profileLastVisit; }
            set { Set(ref _profileLastVisit, value); }
        }
        public IEnumerable<FriendModel> Friends
        {
            get { return _friends; }
            set { Set(ref _friends, value); }
        }
        public IEnumerable<SearchedUser> SearchedUsers
        {
            get { return _searchedUsers; }
            set { Set(ref _searchedUsers, value); }
        }
        private void InitializeCommands()
        {
            LoadCmd = new RelayCommand(Load);
            GoToSettingsCmd = new RelayCommand(GoToSettings);
        }
        
        private void Load()
        {
            InitializeProfile();
            InitializeFakeLists();
        }

        private void InitializeFakeLists()
        {
            var friends = new ObservableCollection<FriendModel>();
            var searched = new ObservableCollection<SearchedUser>();
            var a = new FriendModel
            {
                Id = 1,
                Desc = "Hey there, I'm using new APP :) and it's cool.",
                LastVisit = DateTime.Now.Date.ToString("t"),
                Login = "Ann90",
                PhotoUri =
                    "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcTx7-NNaXJpCNWmUJcHO36WEMWLQS3J0y8d3rjPmpKK5dv8sirrag",
                X = "50.059992",
                Y = "19.8517511"
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
                Y = "19.8517511"
            };
            var e = new FriendModel
            {
                Id = 2,
                Desc = "Dear friends, send me your invitations :))",
                LastVisit = DateTime.Now.Date.ToString("t"),
                Login = "Delcara",
                PhotoUri =
                    " http://media.vogue.com/r/w_660/2014/12/11/best-eyelashes-cara-delevingne.jpg",
                X = "50.059992",
                Y = "19.8517511"
            };
            var c = new SearchedUser
            {
                Id = 2,
                Login = "Andy91",
                PhotoUri =
                    "http://hbz.h-cdn.co/assets/16/10/980x490/landscape-1457457820-hbz-april-2016-jennifer-aniston-a-list-00-index.jpg"
            };
            var d = new SearchedUser
            {
                Id = 2,
                Login = "AnnaKowal90",
                PhotoUri =
                    "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcTx7-NNaXJpCNWmUJcHO36WEMWLQS3J0y8d3rjPmpKK5dv8sirrag",
            };
            var f = new SearchedUser
            {
                Id = 2,
                Login = "AnnaKowal90",
                PhotoUri =
                    " http://media.vogue.com/r/w_660/2014/12/11/best-eyelashes-cara-delevingne.jpg",
            };
            friends.Add(a);
            friends.Add(b);
            friends.Add(e);
            friends.Add(a);
            friends.Add(e);
            friends.Add(b);
            friends.Add(a);
            friends.Add(a);
            friends.Add(e);
            friends.Add(a);
            Friends = friends;

            searched.Add(c);
            searched.Add(d);
            searched.Add(f);
            searched.Add(d);
            searched.Add(f);
            searched.Add(d);
            searched.Add(c);
            searched.Add(f);
            searched.Add(c);
            searched.Add(d);
            searched.Add(c);
            searched.Add(f);
            searched.Add(c);
            searched.Add(d);
            searched.Add(c);
            searched.Add(d);
            searched.Add(f);
            searched.Add(d);
            SearchedUsers = searched;
        }

        private void InitializeProfile()
        {
            ProfileLogin = "Titut94";
            ProfileDescription = "Hello, it's me! :D";
            ProfileUri = "http://i142.photobucket.com/albums/r96/thisdayinmusic/Adele%20hand.jpg";
            ProfileLastVisit = DateTime.Now.ToString("U");


        }

        public void GoBack()
        {
            _navigationService.GoBack();
        }

        private void GoToSettings()
        {
            _navigationService.NavigateTo("Settings");
        }

    }
}

