using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Portable;
using Tillsammens.WindowsPhone.WebServices.Consts;
using Tillsammens.WindowsPhone.WebServices.Dto;
using Tillsammens.WindowsPhone.WebServices.Services.Interfaces;

namespace Tillsammens.WindowsPhone.WebServices.Services
{
    public class TillsammensWebService : RestClientBase, ITillsammensWebService
    {
        public TillsammensWebService()
            : base(TillsammensConsts.BaseAddress)
        {
            
        }

        public async Task<UserModel> CreateAccount(UserModel user)
        {
            var request = new RestRequest(TillsammensConsts.UsersApi, Method.POST);
            request.AddJsonBody(user);
            return await CallAsync<UserModel>(request);
        }
        public async Task<UserModel> Login(string login, string password)
        {
            var request = new RestRequest(TillsammensConsts.ValuesApi, Method.POST);
            request.AddJsonBody(new[] {login, password});
            return await CallAsync<UserModel>(request);
        }
        public async Task<IEnumerable<Invitation>> GetInvitations(int id)
        {
            var request = new RestRequest(TillsammensConsts.InvitationsApi + id, Method.GET);
            return await CallAsync< IEnumerable<Invitation>>(request);
        }
        public async Task<Invitation> SendInvitation(Invitation invitation)
        {
            var request = new RestRequest(TillsammensConsts.InvitationsApi, Method.POST);
            request.AddJsonBody(invitation);
            return await CallAsync<Invitation>(request);
        }
        public async Task<IEnumerable<FriendModel>> GetFriends(int id)
        {
            var request = new RestRequest(TillsammensConsts.UsersApi + id, Method.GET);
            return await CallAsync<IEnumerable<FriendModel>>(request);
        }
        public async Task<IEnumerable<SearchedUser>> SearchFriends(string phrase)
        {
            var request = new RestRequest(TillsammensConsts.ValuesApi + "?phrase=" + phrase, Method.GET);
            return await CallAsync<IEnumerable<SearchedUser>>(request);
        }
        public async Task<UserModel> UpdatePhotoAndDesc(UserModel user)
        {
            var request = new RestRequest(TillsammensConsts.UsersApi+user.Id, Method.PUT);
            request.AddJsonBody(user);
            return await CallAsync<UserModel>(request);
        }
    }
}
