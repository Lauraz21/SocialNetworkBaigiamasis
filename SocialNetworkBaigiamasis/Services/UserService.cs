using SocialNetworkBaigiamasis.DTO;
using SocialNetworkBaigiamasis.Exceptions;
using SocialNetworkBaigiamasis.Models;
using SocialNetworkBaigiamasis.Repositories;
using System.Security.Authentication;
using System.Security.Cryptography;

namespace SocialNetworkBaigiamasis.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void Register(UserCreateDTO user)
        {
            if (string.IsNullOrEmpty(user.Username) || user.Username.Length < 6 ||
                string.IsNullOrEmpty(user.Password) || user.Password.Length < 6)
            {
                throw new ValidationException();
            }

            CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);
            User newUser = new User()
            {
                Username = user.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = UserRoles.User,
                Person = new PersonalInfo()
                {
                    Address = new Address()
                }
            };
            _userRepository.AddUser(newUser);
        }
        public int Login(string userName, string password)
        {
            var user = _userRepository.GetUserByUserName(userName);
            if (user == null)
            {
                throw new AuthenticationException();
            }
            if (VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return user.Id;
            }
            throw new AuthenticationException();
        }
        public void DeleteUser(int userId)
        {
            _userRepository.DeleteUser(userId);
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }

        public UserRoles GetUserRole(int loggedInUserId)
        {
            return _userRepository.GetUserRole(loggedInUserId);
        }
    }
}
