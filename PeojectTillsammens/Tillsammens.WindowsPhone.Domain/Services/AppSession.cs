using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tillsammens.WindowsPhone.WebServices.Dto;

namespace Tillsammens.WindowsPhone.Domain.Services
{
    public sealed class AppSession
    {
        private static readonly Lazy<AppSession> Lazy =
            new Lazy<AppSession>(() => new AppSession());

        private AppSession()
        {
        }

        public static AppSession Current => Lazy.Value;

        public UserModel CurrentUser { get; set; }

        public void Cleanup()
        {
            CurrentUser = null;
        }
    }
}
