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
            AutomapperConfiguration.Configure();
            Kernel.Bind<LoginViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<IDialogService>().To<DialogService>();
            Kernel.Bind<INavigationService>().ToConstant(CreateNavigationService());
        }

        private static NavigationService CreateNavigationService()
        {
            var navigationService = new NavigationService();
            navigationService.Configure("Login", typeof(LoginPage));
            return navigationService;
        }
    }
}
