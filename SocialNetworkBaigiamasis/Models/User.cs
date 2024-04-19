namespace SocialNetworkBaigiamasis.Models
{
    public enum UserRoles
    {
        User,
        Admin
    }
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt{ get; set; }
        public UserRoles Role{ get; set; }
        public PersonalInfo Person{ get; set; }
    }
}
