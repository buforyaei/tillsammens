using System.Diagnostics.CodeAnalysis;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Ninject;

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
        public static void InitializeBootstraper()
        {
            if (BootStrapper != null) return;
            BootStrapper = new Bootstrapper();
            BootStrapper.Initialize();
        }
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }

        public static T GetInstance<T>()
        {
            return BootStrapper.Kernel.Get<T>();
        }
    }
}