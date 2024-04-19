using SocialNetworkBaigiamasis.Models;

namespace SocialNetworkBaigiamasis.Services
{
    public interface IPersonalInfoService
    {
        PersonalInfo GetPersonalInfo(int userId);
        void UpdateAppartmentNumber(int userId, int appartmentNumber);
        void UpdateCountry(int userId, string country);
        void UpdateCity(int userId, string city);
        void UpdateEmail(int userId, string email);
        void UpdateHouseNumber(int userId, int houseNumber);
        void UpdateLastName(int userId, string lastName);
        void UpdateName(int userId, string name);
        void UpdatePersonalCode(int userId, string personalCode);
        void UpdateProfilePicture(int userId, byte[] picture);
        void UpdateStreet(int userId, string street);
        void UpdateTelephoneNumber(int userId, string telephoneNumber);
    }
}