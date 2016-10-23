using System.Diagnostics.Contracts;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Tillsammens.WindowsPhone.App.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public ICommand LoadCmd { get; set; }
        public LoginViewModel()
        {

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
    }
}