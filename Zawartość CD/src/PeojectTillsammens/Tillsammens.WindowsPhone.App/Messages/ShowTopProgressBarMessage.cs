using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;

namespace Tillsammens.WindowsPhone.App.Messages
{
    internal class ShowTopProgressBarMessage : MessageBase
    {
        public ShowTopProgressBarMessage(bool show)
        {
            Show = show;
        }

        public bool Show { get; set; }   
    }
}
