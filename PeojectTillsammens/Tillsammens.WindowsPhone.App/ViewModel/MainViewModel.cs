using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Devices.Geolocation;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Ninject.Infrastructure.Language;
using Tillsammens.WindowsPhone.Domain.Model;
using Tillsammens.WindowsPhone.Domain.Services;
using Tillsammens.WindowsPhone.Domain.Services.Interfaces;
using Tillsammens.WindowsPhone.WebServices.Dto;

namespace Tillsammens.WindowsPhone.App.ViewModel
{
    public class MainViewModel : TillsammensViewModelBase
    {
        private readonly INavigationService _navigationService;
        private ObservableCollection<FriendModel> _friends;
        private IEnumerable<SearchedUser> _searchedUsers;
        private string _profileUri;
        private string _profileLogin;
        private string _profileDescription;
        private string _profileLastVisit;
        private string _searchPhrase;
        private bool _noFriends;
        private bool _isUpdatingProfile;
        private bool _isSearching;
        private bool _noResultsSearched;
        private Invitation _globalCurrentInvitation;

        public ICommand LoadCmd { get; set; }
        public ICommand RemoveFriendCmd { get; set; }
        public ICommand GoToSettingsCmd { get; set; }
        public ICommand OpenMapCmd { get; set; }
        public ICommand LogoutCmd { get; set; }
        public ICommand SearchCmd { get; set; }
        public ICommand UpgdareUserDescOrPhotoCmd { get; set; }
        public ICommand InviteToFriendsCmd { get; set; }

        public MainViewModel(
            INavigationService navigationService,
            IDialogService dialogService,
            ITillsammensService tillsammensService)
            :base(dialogService, tillsammensService)
        {
            _navigationService = navigationService;
            InitializeCommands();
        }
        public bool NoFriends
        {
            get { return _noFriends; }
            set { Set(ref _noFriends, value); }
        }
        public bool IsUpdatingProfile
        {
            get { return _isUpdatingProfile; }
            set { Set(ref _isUpdatingProfile, value); }
        }
        
        public bool NoResultSearched
        {
            get { return _noResultsSearched; }
            set { Set(ref _noResultsSearched, value); }
        }
        public bool IsSearching
        {
            get { return _isSearching; }
            set { Set(ref _isSearching, value); }
        }
        public string SearchPhrase
        {
            get { return _searchPhrase; }
            set { Set(ref _searchPhrase, value); }
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
        public ObservableCollection<FriendModel> Friends
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
            RemoveFriendCmd = new RelayCommand<FriendModel>(RemoveFriend);
            OpenMapCmd = new RelayCommand<FriendModel>(OpenMap);
            SearchCmd = new RelayCommand(SearchUsers);
            UpgdareUserDescOrPhotoCmd = new RelayCommand(UpgradeUserDescOrPhoto);
            InviteToFriendsCmd = new RelayCommand<SearchedUser>(InviteToFriends);
            LogoutCmd = new RelayCommand(Logout);
        }

        private async void Logout()
        {
            var messageDialog = new MessageDialog(
                $"Are you sure you want to logout and quit?", "Logout");
            var yesBtn = new UICommand("Yes")
            {
                Invoked = command =>
                {
                    ViewModelLocator.Cleanup();
                    Application.Current.Exit();
                }
            };
            var noBtn = new UICommand("No");
            messageDialog.Commands.Add(yesBtn);
            messageDialog.Commands.Add(noBtn);
            await messageDialog.ShowAsync();
        }

    
        private async void YesButtonClick(IUICommand command)
        {
            if (_globalSearchedId != 0)
            {
                if (Friends != null && Friends.Any(f => f.Id == _globalSearchedId))
                {
                    await DialogService.ShowMessageBox("You are already friends.", string.Empty);
                    return;
                }
                var result = await TillsammensService.SendInvitationAsync(
                    new Invitation
                    {
                        RecieverId = _globalSearchedId,
                        SenderId = AppSession.Current.CurrentUser.Id,
                        Status = "Confirmable",
                        SenderLogin = AppSession.Current.CurrentUser.Login
                    });
                if (result.WebServiceStatus == WebServiceStatus.Success)
                {
                    await DialogService.ShowMessageBox("Invitation was send succesfully.", string.Empty);
                    return;
                }
                ShowWebResultCommunicate(result.WebServiceStatus);
            }
        }

        private int _globalSearchedId = 0;

        private async void InviteToFriends(SearchedUser searchedUser)
        {
            _globalSearchedId = searchedUser.Id;
            var messageDialog = new MessageDialog(
                $"Are you sure you want to invite {searchedUser.Login} to friends list?", string.Empty);
            var yesBtn = new UICommand("Yes")
            {
                Invoked = YesButtonClick
            };
            messageDialog.Commands.Add(yesBtn);
            var noBtn = new UICommand("No");
            messageDialog.Commands.Add(noBtn);
            await messageDialog.ShowAsync();
        }
        private async void UpgradeUserDescOrPhoto()
        {
            IsUpdatingProfile = true;
            var response = await TillsammensService.UpdatePhotoAndDescAsync(new UserModel
            {
                Id = AppSession.Current.CurrentUser.Id,
                Desc = ProfileDescription,
                PhotoUri = ProfileUri,
            });
            if (response.WebServiceStatus == WebServiceStatus.Success)
            {
                AppSession.Current.CurrentUser.Desc = ProfileDescription;
                AppSession.Current.CurrentUser.PhotoUri = ProfileUri;
                IsUpdatingProfile = false;
                await DialogService.ShowMessageBox("Profile was updated.", string.Empty);
            }
            else
            {
                ProfileDescription = AppSession.Current.CurrentUser.Desc;
                ProfileUri = AppSession.Current.CurrentUser.PhotoUri;
                IsUpdatingProfile = false;
                ShowWebResultCommunicate(response.WebServiceStatus);
            } 
            
        }

        private async void SearchUsers()
        {
            if (string.IsNullOrEmpty(SearchPhrase)) return;
            SearchedUsers = null;
            NoResultSearched = false;
            IsSearching = true;
            var searched = await TillsammensService.SearchFriendsAsync(SearchPhrase);
            if (searched.WebServiceStatus == WebServiceStatus.Success)
            {
                if (searched.Result != null && searched.Result.Any())
                {
                    var searchedWithoutMe = searched.Result
                        .Where(friend => friend.Login != AppSession.Current.CurrentUser.Login)
                        .OrderBy(friend => friend.Login)
                        .ToList();
                        
                    if (searchedWithoutMe.Any())
                    {
                        SearchedUsers = searchedWithoutMe;
                        IsSearching = false;
                        return;
                    }
                }
                IsSearching = false;
                NoResultSearched = true;
                return;

            }
            IsSearching = false;
            ShowWebResultCommunicate(searched.WebServiceStatus);
        }

        private async void RemoveFriend(FriendModel friend)
        {
            var result = await TillsammensService.GetInvitationAsync
                (AppSession.Current.CurrentUser.Id, friend.Id);
            if (result.WebServiceStatus != WebServiceStatus.Success)
            {
                ShowWebResultCommunicate(result.WebServiceStatus);
                return;
            }
            if (result.Result != null)
            {
                var deleteResult = await TillsammensService.DeleteFromFriendsAsync(result.Result.Id);
                if (deleteResult.WebServiceStatus != WebServiceStatus.Success)
                {
                    ShowWebResultCommunicate(deleteResult.WebServiceStatus);
                    return;
                }
                IsWorking = false;
                await new MessageDialog("Friend was successfully removed.", "Delete friend").ShowAsync();
                await InitializeFriendsList();
            }
            

        }

        private void OpenMap(FriendModel friend)
        {
            if (AppSession.Current.FriendsList != null && AppSession.Current.FriendsList.Any())
            {
                _navigationService.NavigateTo("Map", friend);
            }
        }

        private async void Load()
        {
            InitializeProfile();
            await InitializeFriendsList();
            await UpdateGeoPosition();
            await GetInvitations();
        }

        private async Task UpdateGeoPosition()
        {
            var myGeoposition = await new Geolocator().GetGeopositionAsync();
            var response = await TillsammensService.UpdateGpsAsync(new UserModel
            {
                Id = AppSession.Current.CurrentUser.Id,
                LastVisit = DateTime.Now,
                X = myGeoposition.Coordinate.Point.Position.Latitude,
                Y = myGeoposition.Coordinate.Point.Position.Longitude,
            });
        }

        private async Task GetInvitations()
        {
            var invitations =
                await TillsammensService.GetInvitationsAsync
                    (AppSession.Current.CurrentUser.Id);
            if (invitations.WebServiceStatus != WebServiceStatus.Success)
            {
                return;
            }
            if (invitations.Result != null && invitations.Result.Any())
            {
                await ShowInvitations(invitations.Result);
                return;
            }

        }

        private async void AcceptButtonClick(IUICommand command)
        { 
            _globalCurrentInvitation.Status = "Accepted";
            await TillsammensService.UpdateInvitationsAsync(_globalCurrentInvitation);
        }
        private async void RejectButtonClick(IUICommand command)
        {
            
            _globalCurrentInvitation.Status = "Rejected";
            await TillsammensService.UpdateInvitationsAsync(_globalCurrentInvitation);
        }
        private async Task ShowInvitations(IEnumerable<Invitation> invitations)
        {
            var messageDialog = new MessageDialog(String.Empty,"Invitation");
            var yesBtn = new UICommand("Accept")
            {
                Invoked = AcceptButtonClick
            };
            messageDialog.Commands.Add(yesBtn);
            var noBtn = new UICommand("Reject")
            {
                Invoked = RejectButtonClick
            };
            messageDialog.Commands.Add(noBtn);
            foreach (var i in invitations)
            {
                if (i.Status.Contains("Confirmable"))
                {
                    messageDialog.Content = $"{i.SenderLogin} wants to add you to friends list.";
                    _globalCurrentInvitation = i;
                    await messageDialog.ShowAsync(); 
                }
            }
        }
        private async Task InitializeFriendsList()
        {
            NoFriends = false;
            Friends = null;
            IsWorking = true;
            var friends = await TillsammensService.GetFriendsAsync(
                AppSession.Current.CurrentUser.Id);
            if (friends.WebServiceStatus != WebServiceStatus.Success)
            {
                IsWorking = false;
                ShowWebResultCommunicate(friends.WebServiceStatus);
                return;
            }
            if (friends.Result == null || !friends.Result.Any())
            {
                IsWorking = false;
                NoFriends = true;
            }
            else
            {
                IsWorking = false;
                Friends = new ObservableCollection<FriendModel>(
                    friends.Result.OrderBy(friend => friend.LastVisit));
                AppSession.Current.FriendsList = Friends.ToList();
            }
        }

        private void InitializeProfile()
        {
            if (AppSession.Current.CurrentUser != null)
            {
                ProfileLogin = AppSession.Current.CurrentUser.Login;
                ProfileDescription = AppSession.Current.CurrentUser.Desc;
                ProfileUri = AppSession.Current.CurrentUser.PhotoUri;
                ProfileLastVisit = AppSession.Current.CurrentUser.LastVisit.ToString("g");
            }
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

