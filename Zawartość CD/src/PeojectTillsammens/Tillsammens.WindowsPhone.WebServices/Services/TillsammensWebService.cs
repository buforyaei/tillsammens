using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Authentication.OnlineId;
using RestSharp.Portable;
using Tillsammens.WindowsPhone.WebServices.Consts;
using Tillsammens.WindowsPhone.WebServices.Dto;
using Tillsammens.WindowsPhone.WebServices.Services.Interfaces;

namespace Tillsammens.WindowsPhone.WebServices.Services
{
    public class TillsammensWebService : RestClientBase, ITillsammensWebService
    {
        public TillsammensWebService()
            : base(TillsammensConsts.BaseAddress){}

        public async Task<UserModel> CreateAccount(UserModel user)
        {
            var request = new RestRequest(TillsammensConsts.UsersApi, Method.POST);
            request.AddJsonBody(user);
            return await CallAsync<UserModel>(request);
        }

        public async Task<UserModel> Login(string login, string password)
        {
            var request = new RestRequest(TillsammensConsts.LoginApi, Method.POST);
            request.AddJsonBody(new[] {login, password});
            return await CallAsync<UserModel>(request);
        }

        public async Task<IEnumerable<Invitation>> GetInvitations(int id)
        {
            var request = new RestRequest(TillsammensConsts.InvitationsApi + id, Method.GET);
            return await CallAsync< IEnumerable<Invitation>>(request);
        }

        public async Task<IEnumerable<FriendModel>> GetFriends(int id)
        {
            var request = new RestRequest(TillsammensConsts.FreindsApi + id, Method.GET);
            return await CallAsync<IEnumerable<FriendModel>>(request);
        }

        public async Task<IEnumerable<SearchedUser>> SearchFriends(string phrase)
        {
            var request = new RestRequest(TillsammensConsts.SearchApi + "?phrase=" + phrase, Method.GET);
            return await CallAsync<IEnumerable<SearchedUser>>(request);
        }

        public async Task<UserModel> UpdatePhotoAndDesc(UserModel user)
        {
            var request = new RestRequest(TillsammensConsts.UpdateDescPhotoApi, Method.POST);
            request.AddJsonBody(user);
            return await CallAsync<UserModel>(request);
        }

        public async Task<Invitation> SendInvitation(Invitation invitation)
        {
            var request = new RestRequest(TillsammensConsts.InvitationsApi, Method.POST);
            request.AddJsonBody(invitation);
            return await CallAsync<Invitation>(request);
        }

        public async Task<UserModel> UpdateGps(UserModel user)
        {
            var request = new RestRequest(TillsammensConsts.UpdateGpsApi, Method.POST);
            request.AddJsonBody(user);
            return await CallAsync<UserModel>(request);
        }

        public async Task<Invitation> UpdateInvitation(Invitation invitation)
        {
            var request = new RestRequest(TillsammensConsts.InvitationsApi + invitation.Id, Method.PUT);
            request.AddJsonBody(invitation);
            return await CallAsync<Invitation>(request);
        }

        public async Task<Invitation> GetInvitation(int userId, int friendId)
        {
            var request = new RestRequest(TillsammensConsts.InvitationApi, Method.POST);
            request.AddJsonBody(new[]{userId,friendId});
            return await CallAsync<Invitation>(request);
        }

        public async Task<Invitation> DeleteFromFriends(int invitationId)
        {
            var request = new RestRequest(TillsammensConsts.InvitationsApi + invitationId, Method.DELETE);
            return await CallAsync<Invitation>(request);
        }

        public async Task<bool> DeleteAccount(int id)
        {
            var request = new RestRequest(TillsammensConsts.RemoveAccountApi + id, Method.POST);
            return await CallAsync<bool>(request);
        }

        public async Task<UserModel> ChangePassword(UserModel user)
        {
            var request = new RestRequest(TillsammensConsts.ChangePassword, Method.POST);
            request.AddJsonBody(user);
            return await CallAsync<UserModel>(request);
        }
    }
}
