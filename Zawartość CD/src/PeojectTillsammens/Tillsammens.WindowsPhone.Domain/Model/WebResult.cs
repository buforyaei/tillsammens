using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tillsammens.WindowsPhone.Domain.Model
{
    public class WebResult<T>
    {
        public WebResult(WebServiceStatus webServiceStatus)
        {
            WebServiceStatus = webServiceStatus;
            Result = default(T);
        }

        public WebResult(T result)
        {
            WebServiceStatus = WebServiceStatus.Success;
            Result = result;
        }

        public WebServiceStatus WebServiceStatus { get; set; }
        public T Result { get; set; }
    }
}
