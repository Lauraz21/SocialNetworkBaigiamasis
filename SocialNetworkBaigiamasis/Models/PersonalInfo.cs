namespace SocialNetworkBaigiamasis.Models
{
    public class PersonalInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PersonalCode { get; set; }
        public string TelephoneNumber{ get; set; }
        public string Email{ get; set; }
        public byte[] ProfilePicture{ get; set; }
        public Address Address { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}