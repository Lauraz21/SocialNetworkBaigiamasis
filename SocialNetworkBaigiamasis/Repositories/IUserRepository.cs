using SocialNetworkBaigiamasis.Models;

namespace SocialNetworkBaigiamasis.Repositories
{
    public interface IUserRepository
    {
        User GetUserByUserName(string userName);
        void AddUser(User user);
        void DeleteUser(int userId);
        UserRoles GetUserRole(int userId);
    }
}
