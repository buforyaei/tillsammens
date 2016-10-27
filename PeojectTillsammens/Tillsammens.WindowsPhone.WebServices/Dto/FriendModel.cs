using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tillsammens.WindowsPhone.WebServices.Dto
{
    public class FriendModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PhotoUri { get; set; }
        public string MailAddress { get; set; }
        public string LastVisit { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string Desc { get; set; }
    }
}
