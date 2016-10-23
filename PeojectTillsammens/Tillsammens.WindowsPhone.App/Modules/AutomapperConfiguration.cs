using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Tillsammens.WindowsPhone.App.Modules
{
    public static class AutomapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
        }
    }
}
