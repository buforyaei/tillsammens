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
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public ICommand LoadCmd { get; set; }
        public ICommand CreateAccountCmd { get; set; }

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            LoadCmd = new RelayCommand(Load);
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

