using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Tillsammens.WindowsPhone.Domain.Model;
using Tillsammens.WindowsPhone.Domain.Services.Interfaces;
using Tillsammens.WindowsPhone.WebServices.Dto;

namespace Tillsammens.WindowsPhone.App.ViewModel
{
    public class CreateAccountViewModel : TillsammensViewModelBase
    {
        private readonly INavigationService _navigationService;

        public ICommand LoadCmd { get; set; }
        public ICommand CreateAccountCmd { get; set; }

        public CreateAccountViewModel(
            INavigationService navigationService,
            IDialogService dialogService,
            ITillsammensService tillsammensService)
            : base(dialogService, tillsammensService)
        {
            _navigationService = navigationService;
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            LoadCmd = new RelayCommand(Load);
            CreateAccountCmd = new RelayCommand<string[]>(CreateAccount);
        }
        private async void CreateAccount(string[] credentials)
        {
            IsWorking = true;
            if (string.IsNullOrEmpty(credentials[0]) 
                || string.IsNullOrEmpty(credentials[1]) 
                || string.IsNullOrEmpty(credentials[2]))
            {
                IsWorking = false;
                await DialogService.ShowMessageBox(
                    "Fields can not be empty!", "Error");
                return;
            }
            if (credentials[0].Length > 25)
            {
                IsWorking = false;
                await DialogService.ShowMessageBox(
                    "Login is too long!", "Error");
                return;
            }
            if(credentials[1] != credentials[2])
            {
                IsWorking = false;
                await DialogService.ShowMessageBox(
                    "Passwords must not be different!", "Error");
                return;
            }
            var user = await TillsammensService.CreateAccountAsync(
                new UserModel
                {
                    Login = credentials[0],
                    Password = credentials[1],
                    CloseDate = DateTime.MaxValue,
                    OpenDate = DateTime.Now,
                    Desc = "Hey there I'm using tillsamens!",
                    LastVisit = DateTime.Now,
                    PhotoUri = String.Empty,
                    X = 0,
                    Y = 0,
                });
            if (user.WebServiceStatus == WebServiceStatus.Success)
            {
                IsWorking = false;
                await DialogService.ShowMessageBox(
                    "Your account has been created!", "Success");
                _navigationService.GoBack();
                return;
            }
            IsWorking = false;
            ShowWebResultCommunicate(user.WebServiceStatus);
        }

        private void Load() { }

        public void GoBack()
        {
            _navigationService.GoBack();
        }
    }
}

