using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tillsammens.WindowsPhone.Domain.Model;
using Tillsammens.WindowsPhone.WebServices.Dto;

namespace Tillsammens.WindowsPhone.Domain.Services.Interfaces
{
    public interface ITillsammensService
    {
        Task<WebResult<UserModel>> CreateAccountAsync(UserModel user);

        Task<WebResult<UserModel>> LoginAsync(string login, string password);
    }
}
