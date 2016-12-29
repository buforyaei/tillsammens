using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Pickers.Provider;

namespace Tillsammens.WindowsPhone.WebServices.Dto
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PhotoUri { get; set; }
        public string LastVisit { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public string Desc { get; set; }
        public string OpenDate { get; set; }
        public string CloseDate { get; set; }
       
    }
}
