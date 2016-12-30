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
    }
}
