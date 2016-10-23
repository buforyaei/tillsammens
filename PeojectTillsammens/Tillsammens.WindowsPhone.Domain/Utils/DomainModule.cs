using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Tillsammens.WindowsPhone.Domain.Services;
using Tillsammens.WindowsPhone.Domain.Services.Interfaces;

namespace Tillsammens.WindowsPhone.Domain.Utils
{
    public class DomainModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<ITillsammensService>().To<TillsammensService>().InSingletonScope();
        }
    }
}
