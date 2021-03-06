using System.Diagnostics.CodeAnalysis;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using Tillsammens.WindowsPhone.Domain.Services;

namespace Tillsammens.WindowsPhone.App.ViewModel
{
    public class ViewModelLocator
    {
        public static Bootstrapper BootStrapper; 

        static ViewModelLocator()
        {
            InitializeBootstraper();
        }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public LoginViewModel Login
        {
                get { return BootStrapper.Kernel.Get<LoginViewModel>(); }
        }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public CreateAccountViewModel CreateAcccount
        {
            get { return BootStrapper.Kernel.Get<CreateAccountViewModel>(); }
        }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public MainViewModel Main
        {
            get { return BootStrapper.Kernel.Get<MainViewModel>(); }
        }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public SettingsViewModel Settings
        {
            get { return BootStrapper.Kernel.Get<SettingsViewModel>(); }
        }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public MapViewModel Map
        {
            get { return BootStrapper.Kernel.Get<MapViewModel>(); }
        }

        public static void InitializeBootstraper()
        {
            if (BootStrapper != null) return;
            BootStrapper = new Bootstrapper();
            BootStrapper.Initialize();
        }
        public static void Cleanup()
        {
            AppSession.Current.CurrentUser = null;
        }

        public static T GetInstance<T>()
        {
            return BootStrapper.Kernel.Get<T>();
        }
    }
}