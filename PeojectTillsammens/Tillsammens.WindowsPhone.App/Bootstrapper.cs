using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using Tillsammens.WindowsPhone.App.Modules;
using Tillsammens.WindowsPhone.Domain.Utils;

namespace Tillsammens.WindowsPhone.App
{
    public class Bootstrapper : IDisposable
    {
        public IKernel Kernel { get; set; }

        public void Dispose()
        {
            Kernel.Dispose();
        }

        public void Initialize()
        {
            Kernel = ConfigureAppKernel();
        }

        private IKernel ConfigureAppKernel()
        {
            var kernel = new StandardKernel();
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            if (ViewModelBase.IsInDesignModeStatic)
            {
                kernel.Load<Tillsammens.WindowsPhone.Domain.Modules.WebServicesModule>();
                kernel.Load<DomainModule>();
                kernel.Load<UiModule>();
            }
            else
            {
                kernel.Load<Tillsammens.WindowsPhone.Domain.Modules.WebServicesModule>();
                kernel.Load<DomainModule>();
                kernel.Load<UiModule>();
            }

            return kernel;
        }
    }
}
