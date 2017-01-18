using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Devices.Geolocation;
using Windows.UI.Popups;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Tillsammens.WindowsPhone.Domain.Model;
using Tillsammens.WindowsPhone.Domain.Services;
using Tillsammens.WindowsPhone.Domain.Services.Interfaces;
using Tillsammens.WindowsPhone.WebServices.Dto;

namespace Tillsammens.WindowsPhone.App.ViewModel
{
    public class SettingsViewModel : TillsammensViewModelBase
    {
        private readonly INavigationService _navigationService;

        public ICommand LoadCmd { get; set; }
        public ICommand ChangePasswordCmd { get; set; }
        public ICommand DeleteAccountCmd { get; set; }
        public ICommand ChangePasswordsVisCmd { get; set; }
        private bool _showPasswordBoxes;


        public SettingsViewModel(
            INavigationService navigationService,
            IDialogService dialogService,
            ITillsammensService tillsammensService)
            :base(dialogService, tillsammensService)
        {
            _navigationService = navigationService;
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            LoadCmd = new RelayCommand(Load);
            ChangePasswordCmd = new RelayCommand<string[]>(ChangePassword);
            DeleteAccountCmd = new RelayCommand(DeleteAccount);
            ChangePasswordsVisCmd = new RelayCommand(ChangePasswordsVis);
        }

        private void Load() { }

        public void GoBack()
        {
            _navigationService.GoBack();
        }

        public bool ShowPasswordBoxes
        {
            get { return _showPasswordBoxes; }
            set { Set(ref _showPasswordBoxes, value); }
        }

        private void ChangePasswordsVis()
        {
            ShowPasswordBoxes = !ShowPasswordBoxes;
        }

        private async void ChangePassword(string[] credentials)
        {
            if (string.IsNullOrEmpty(credentials[0]) || 
                string.IsNullOrEmpty(credentials[1]) ||
                string.IsNullOrEmpty(credentials[2]))
            {
                await DialogService.ShowMessage("Fields can not be empty.", "Error");
                return;
            }
            if (credentials[0] != AppSession.Current.CurrentUser.Password)
            {
                await DialogService.ShowMessage("Old password is not correct.","Error");
                return;
            }
            if (credentials[1] != credentials[2])
            {
                await DialogService.ShowMessage("New password is not repeated correctly.", "Error");
                return;
            }
            ShowPasswordBoxes = false;
            IsWorking = true;
            var result = await TillsammensService.ChangePasswordAsync(new UserModel
            {
                Id = AppSession.Current.CurrentUser.Id,
                Password = EncryptPassword(credentials[1])
            });
            if (result.WebServiceStatus != WebServiceStatus.Success)
            {
                IsWorking = false;
                ShowPasswordBoxes = true;
                ShowWebResultCommunicate(result.WebServiceStatus);
                return;
            }
            IsWorking = false;
            await DialogService.ShowMessage("Password was correctly changed.", "Success");
            _navigationService.NavigateTo("Login");

        }

        private string EncryptPassword(string p)
        {
            return p;
        }

        private async void DeleteAccount()
        {
            var messageDialog = new MessageDialog(
                $"Are you sure you want delete your account?", "Delete account");
            var yesBtn = new UICommand("Yes")
            {
                Invoked = YesButtonClick
            };
            messageDialog.Commands.Add(yesBtn);
            var noBtn = new UICommand("No");
            messageDialog.Commands.Add(noBtn);
            await messageDialog.ShowAsync();
        }

        private async void YesButtonClick(IUICommand command)
        {
            ShowPasswordBoxes = false;
            IsWorking = true;
            var result = await TillsammensService.DeleteAccountAsync
                (AppSession.Current.CurrentUser.Id);
            if (result.WebServiceStatus != WebServiceStatus.Success)
            {
                IsWorking = false;
                ShowWebResultCommunicate(result.WebServiceStatus);
                return;
            }
            if (result.Result)
            {
                IsWorking = false;
                await DialogService.ShowMessage("Account was removed successfully.", "Delete account");
                _navigationService.NavigateTo("Login");
                return;
            }
            IsWorking = false;
            await DialogService.ShowMessage("Unexpected error occured.", "Delete account");
        }

        

    }
}
