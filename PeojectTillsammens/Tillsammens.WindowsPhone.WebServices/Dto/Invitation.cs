using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tillsammens.WindowsPhone.WebServices.Dto
{
    public class Invitation
    {
        public int Id { get; set; }
        public int RecieverId { get; set; }
        public int SenderId { get; set; }
        public string Status { get; set; }
        public string SenderLogin { get; set; }
    }
}
