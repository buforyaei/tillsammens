using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tillsammens.WindowsPhone.Domain.Model;
using Tillsammens.WindowsPhone.Domain.Services.Interfaces;
using Tillsammens.WindowsPhone.WebServices.Dto;
using Tillsammens.WindowsPhone.WebServices.Services.Interfaces;

namespace Tillsammens.WindowsPhone.Domain.Services
{
    public class TillsammensService : BaseService, ITillsammensService
    {
        private readonly ITillsammensWebService _tillsammensWebService;


        public TillsammensService(ITillsammensWebService tillsammensWebService)
        {
            _tillsammensWebService = tillsammensWebService;
        }

        public async Task<WebResult<UserModel>> CreateAccountAsync(UserModel user)
        {
            return await GetWebServiceData(() => _tillsammensWebService.CreateAccount(user));
        }

        public async Task<WebResult<UserModel>> LoginAsync(string login, string password)
        {
            return await GetWebServiceData(() => _tillsammensWebService.Login(login, password));
        }

    }
}
