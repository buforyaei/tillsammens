using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace Tillsammens.WindowsPhone.App.ViewModel
{
    public class CreateAccountViewModel :ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public ICommand LoadCmd { get; set; }
        public ICommand CreateAccountCmd { get; set; }

        public CreateAccountViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            LoadCmd = new RelayCommand(Load);
            CreateAccountCmd = new RelayCommand(CreateAccount);
        }
        private void CreateAccount()
        {
            int a = 9;
        }
        private void Load()
        {
            int a = 9;
        }

        public void GoBack()
        {
            _navigationService.GoBack();
        }

    }
}

