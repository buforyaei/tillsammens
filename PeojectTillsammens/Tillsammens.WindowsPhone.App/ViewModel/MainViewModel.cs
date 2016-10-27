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
using Tillsammens.WindowsPhone.WebServices.Dto;

namespace Tillsammens.WindowsPhone.App.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private IEnumerable<FriendModel> _friends; 
        public ICommand LoadCmd { get; set; }
        public ICommand GoToSettingsCmd { get; set; }

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            InitializeCommands();
        }

        public IEnumerable<FriendModel> Friends
        {
            get { return _friends; }
            set { Set(ref _friends, value); }
        } 
        private void InitializeCommands()
        {
            LoadCmd = new RelayCommand(Load);
            GoToSettingsCmd = new RelayCommand(GoToSettings);
        }
       
        private void Load()
        {
            var friends = new ObservableCollection<FriendModel>();
            var a = new FriendModel
            {
                Id = 1,
                Desc = "Hey there, I'm using new APP :) and it's cool.",
                LastVisit = DateTime.Now.Date.ToString("t"),
                Login = "Ann90",
                MailAddress = "annblack@gmail.com",
                PhotoUri =
                    "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcTx7-NNaXJpCNWmUJcHO36WEMWLQS3J0y8d3rjPmpKK5dv8sirrag",
                X = "50.059992",
                Y = "19.8517511"

            };
            var b = new FriendModel
            {
                Id = 2,
                Desc = "Czekam na operacje biodra :))",
                LastVisit = DateTime.Now.Date.ToString("t"),
                Login = "Grażynka",
                MailAddress = "annblack@gmail.com",
                PhotoUri =
                   "https://scontent-waw1-1.xx.fbcdn.net/v/t1.0-1/c0.0.160.160/p160x160/941219_612965298737442_1473867419_n.jpg?oh=abcddd9b8a7e6aabac40a33bb78088ea&oe=58883636",
                X = "50.059992",
                Y = "19.8517511"

            };
            friends.Add(a);
            friends.Add(b);
            friends.Add(a);
            friends.Add(a);
            friends.Add(a);
            friends.Add(a);
            friends.Add(a);
            friends.Add(a);
            friends.Add(a);
            friends.Add(a);
            Friends = friends;
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

