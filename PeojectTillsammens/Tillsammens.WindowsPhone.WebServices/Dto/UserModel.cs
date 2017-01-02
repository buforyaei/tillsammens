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
        public DateTime LastVisit { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public string Desc { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
       
    }
}
