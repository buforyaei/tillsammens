using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tillsammens.WindowsPhone.WebServices.Dto;

namespace Tillsammens.WindowsPhone.WebServices.Services.Interfaces
{
    public interface ITillsammensWebService
    {
        Task<UserModel> CreateAccount(UserModel user);

        Task<UserModel> Login(string login, string password);
    }
}
