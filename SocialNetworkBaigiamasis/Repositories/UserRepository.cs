using Microsoft.EntityFrameworkCore;
using SocialNetworkBaigiamasis.Data;
using SocialNetworkBaigiamasis.Models;

namespace SocialNetworkBaigiamasis.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        private readonly ApplicationDbContext _context;
        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public User GetUserByUserName(string userName)
        {
            return _context.Users?.FirstOrDefault(u => u.Username == userName);
        }

        public void DeleteUser(int userId)
        {
            User user = _context.Users.Include(user => user.Person).Include(user => user.Person.Address).FirstOrDefault(user => user.Id == userId);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public UserRoles GetUserRole(int userId)
        {
            var user = _context.Users?.FirstOrDefault(u => u.Id == userId);
            return user.Role;
        }
    }
}
