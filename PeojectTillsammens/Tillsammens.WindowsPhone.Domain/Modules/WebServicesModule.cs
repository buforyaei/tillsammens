using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Tillsammens.WindowsPhone.WebServices.Services;
using Tillsammens.WindowsPhone.WebServices.Services.Interfaces;

namespace Tillsammens.WindowsPhone.Domain.Modules
{
    public class WebServicesModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<ITillsammensWebService>().To<TillsammensWebService>().InSingletonScope();
        }
    }
}
