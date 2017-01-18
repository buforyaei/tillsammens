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

        Task<IEnumerable<Invitation>> GetInvitations(int id);

        Task<IEnumerable<FriendModel>> GetFriends(int id);

        Task<IEnumerable<SearchedUser>> SearchFriends(string phrase);

        Task<UserModel> UpdatePhotoAndDesc(UserModel user);

        Task<Invitation> SendInvitation(Invitation invitation);

        Task<UserModel> UpdateGps(UserModel user);

        Task<Invitation> UpdateInvitation(Invitation invitation);

        Task<Invitation> GetInvitation(int userId, int friendId);

        Task<Invitation> DeleteFromFriends(int invitationId);

        Task<bool> DeleteAccount(int id);

        Task<UserModel> ChangePassword(UserModel user);

    }
}
