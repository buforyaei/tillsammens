using System;
using System.Diagnostics.Contracts;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Tillsammens.WindowsPhone.Domain.Model;
using Tillsammens.WindowsPhone.Domain.Services;
using Tillsammens.WindowsPhone.Domain.Services.Interfaces;

namespace Tillsammens.WindowsPhone.App.ViewModel
{
    public class LoginViewModel : TillsammensViewModelBase
    {
        private readonly INavigationService _navigationService;

        public ICommand LoadCmd { get; set; }
        public ICommand LoginCmd { get; set; }
        public ICommand OpenCreateAccountCmd { get; set; }

        public LoginViewModel(
            INavigationService navigationService, 
            ITillsammensService tillsammensService,
            IDialogService dialogService)
            :base(dialogService, tillsammensService)
        {
            _navigationService = navigationService;
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            LoadCmd = new RelayCommand(Load);
            OpenCreateAccountCmd = new RelayCommand(OpenCreateAccount);
            LoginCmd = new RelayCommand<string[]>(Login);
        }
        private void Load() { }

        private async void Login(string[] credentials)
        {
            IsWorking = true;
            if (string.IsNullOrEmpty(credentials[0])
                || string.IsNullOrEmpty(credentials[1]))
            {
                IsWorking = false;
                await DialogService.ShowMessageBox(
                    "Fields can not be empty.", string.Empty);
                return;
            }
            var user = await TillsammensService.LoginAsync(credentials[0], credentials[1]);
            if (user.WebServiceStatus == WebServiceStatus.Success
                && user.Result != null)
            {
                AppSession.Current.CurrentUser = user.Result;
                IsWorking = false;
                _navigationService.NavigateTo("Main");
                return;
            }
            IsWorking = false;
            ShowWebResultCommunicate(user.WebServiceStatus);
        }

        private void OpenCreateAccount()
        {
            _navigationService.NavigateTo("CreateAccount");
        }
    }
}