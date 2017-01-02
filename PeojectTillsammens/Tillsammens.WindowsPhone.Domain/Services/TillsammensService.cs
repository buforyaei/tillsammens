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

        public async Task<WebResult<IEnumerable<Invitation>>> GetInvitationsAsync(int id)
        {
            return await GetWebServiceData(() => _tillsammensWebService.GetInvitations(id));
        }

        public async Task<WebResult<Invitation>> SendInvitationAsync(Invitation invitation)
        {
            return await GetWebServiceData(() => _tillsammensWebService.SendInvitation(invitation));
        }

        public async Task<WebResult<IEnumerable<FriendModel>>> GetFriendsAsync(int id)
        {
            return await GetWebServiceData(() => _tillsammensWebService.GetFriends(id));
        }

        public async Task<WebResult<IEnumerable<SearchedUser>>> SearchFriendsAsync(string phrase)
        {
            return await GetWebServiceData(() => _tillsammensWebService.SearchFriends(phrase));
        }

        public async Task<WebResult<UserModel>> UpdatePhotoAndDescAsync(UserModel user)
        {
            return await GetWebServiceData(() => _tillsammensWebService.UpdatePhotoAndDesc(user));
        }

        public async Task<WebResult<UserModel>> UpdateGpsAsync(UserModel user)
        {
            return await GetWebServiceData(() => _tillsammensWebService.UpdateGps(user));
        }

        public async Task<WebResult<Invitation>> UpdateInvitationsAsync(Invitation invitation)
        {
            return await GetWebServiceData(() => _tillsammensWebService.UpdateInvitation(invitation));
        }
        public async Task<WebResult<Invitation>> GetInvitationAsync(int userId, int friendId)
        {
            return await GetWebServiceData(() => _tillsammensWebService.GetInvitation(userId,friendId));
        }
        public async Task<WebResult<Invitation>> DeleteFromFriendsAsync(int invitationId)
        {
            return await GetWebServiceData(() => _tillsammensWebService.DeleteFromFriends(invitationId));
        }
    }
}
