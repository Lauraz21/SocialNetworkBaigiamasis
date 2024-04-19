using SocialNetworkBaigiamasis.DTO;
using SocialNetworkBaigiamasis.Models;

namespace SocialNetworkBaigiamasis.Services
{
    public interface IUserService
    {
        void Register(UserCreateDTO user);
        int Login(string userName, string password);
        void DeleteUser(int userId);
        UserRoles GetUserRole(int loggedInUserId);
    }
}