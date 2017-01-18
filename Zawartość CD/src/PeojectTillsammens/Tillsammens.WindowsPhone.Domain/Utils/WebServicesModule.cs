using Tillsammens.WindowsPhone.WebServices.Services;
using Tillsammens.WindowsPhone.WebServices.Services.Interfaces;
using Ninject.Modules;

namespace Tillsammens.WindowsPhone.Domain.Utils
{
    class WebServicesModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<ITillsammensWebService>().To<TillsammensWebService>().InSingletonScope();
        }
    }
}
