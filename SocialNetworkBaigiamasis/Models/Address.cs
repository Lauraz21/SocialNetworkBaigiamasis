namespace SocialNetworkBaigiamasis.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int AppartmentNumber { get; set; }
        public PersonalInfo Person { get; set; }
        public int PersonId { get; set; }
    }
}