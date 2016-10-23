using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tillsammens.WindowsPhone.Domain.Model
{
    public enum WebServiceStatus
    {
        Success,
        Unauthorized,
        ServiceError,
        ConnectionError
    }
}
