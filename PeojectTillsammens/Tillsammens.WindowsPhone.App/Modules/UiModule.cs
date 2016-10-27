using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;
using Ninject.Modules;
using Tillsammens.WindowsPhone.App.Pages;
using Tillsammens.WindowsPhone.App.ViewModel;

namespace Tillsammens.WindowsPhone.App.Modules
{
    public class UiModule : NinjectModule
    {
        public override void Load()
        {
            //AutomapperConfiguration.Configure();
            Kernel.Bind<LoginViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<CreateAccountViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<MainViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<SettingsViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<IDialogService>().To<DialogService>();
            Kernel.Bind<INavigationService>().ToConstant(CreateNavigationService());
        }

        private static NavigationService CreateNavigationService()
        {
            var navigationService = new NavigationService();
            navigationService.Configure("Login", typeof(LoginPage));
            navigationService.Configure("CreateAccount", typeof(CreateAccountPage));
            navigationService.Configure("Main", typeof(MainPage));
            navigationService.Configure("Settings", typeof(SettingsPage));
            return navigationService;
        }
         
    }
}
