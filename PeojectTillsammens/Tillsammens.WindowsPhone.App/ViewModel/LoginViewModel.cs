using System.Diagnostics.Contracts;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace Tillsammens.WindowsPhone.App.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public ICommand LoadCmd { get; set; }
        public ICommand LoginCmd { get; set; }
        public ICommand OpenCreateAccountCmd { get; set; }

        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            LoadCmd = new RelayCommand(Load);
            OpenCreateAccountCmd = new RelayCommand(OpenCreateAccount);
            LoginCmd = new RelayCommand(Login);
        }
        private void Load() { }

        private void Login()
        {
            _navigationService.NavigateTo("Main");
        }

        private void OpenCreateAccount()
        {
            _navigationService.NavigateTo("CreateAccount");
        }
    }
}