using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace Tillsammens.WindowsPhone.WebServices.Dto
{
    public class FriendModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PhotoUri { get; set; }
        public DateTime LastVisit { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public string Desc { get; set; }
        public Geopoint Geopoint { get; set; }
    }
}
