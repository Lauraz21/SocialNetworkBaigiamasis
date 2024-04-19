using Microsoft.EntityFrameworkCore;
using SocialNetworkBaigiamasis.Data;
using SocialNetworkBaigiamasis.Exceptions;
using SocialNetworkBaigiamasis.Models;

namespace SocialNetworkBaigiamasis.Services
{
    public class PersonalInfoService : IPersonalInfoService
    {
        private readonly ApplicationDbContext _context;

        public PersonalInfoService(ApplicationDbContext context)
        {
            _context = context;
        }
        public PersonalInfo GetPersonalInfo(int userId)
        {
            User user = _context.Users.Include(user => user.Person).Include(user => user.Person.Address).FirstOrDefault(user => user.Id == userId);
            return user.Person;
        }

        public void UpdateName(int userId, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ValidationException();
            }
            User user = _context.Users.Include(user => user.Person).FirstOrDefault(user => user.Id == userId);
            user.Person.Name = name;
            _context.SaveChanges();
        }
        public void UpdateLastName(int userId, string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
            {
                throw new ValidationException();
            }
            User user = _context.Users.Include(user => user.Person).FirstOrDefault(user => user.Id == userId);
            user.Person.LastName = lastName;
            _context.SaveChanges();
        }
        public void UpdatePersonalCode(int userId, string personalCode)
        {
            if (string.IsNullOrEmpty(personalCode) || personalCode.Length != 11) //12345678999
            {
                throw new ValidationException();
            }
            User user = _context.Users.Include(user => user.Person).FirstOrDefault(user => user.Id == userId);
            user.Person.PersonalCode = personalCode;
            _context.SaveChanges();
        }
        public void UpdateTelephoneNumber(int userId, string telephoneNumber)
        {
            if (string.IsNullOrEmpty(telephoneNumber) || telephoneNumber.Length != 12) //+37000000000
            {
                throw new ValidationException();
            }
            User user = _context.Users.Include(user => user.Person).FirstOrDefault(user => user.Id == userId);
            user.Person.TelephoneNumber = telephoneNumber;
            _context.SaveChanges();
        }
        public void UpdateEmail(int userId, string email)
        {
            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
            {
                throw new ValidationException();
            }
            User user = _context.Users.Include(user => user.Person).FirstOrDefault(user => user.Id == userId);
            user.Person.Email = email;
            _context.SaveChanges();
        }
        public void UpdateProfilePicture(int userId, byte[] picture)
        {
            if (picture.Length == 0)
            {
                throw new ValidationException();
            }
            User user = _context.Users.Include(user => user.Person).FirstOrDefault(user => user.Id == userId);
            user.Person.ProfilePicture = picture;
            _context.SaveChanges();
        }
        public void UpdateCountry(int userId, string country)
        {
            if (string.IsNullOrEmpty(country))
            {
                throw new ValidationException();
            }
            User user = _context.Users.Include(user => user.Person).Include(user => user.Person.Address).FirstOrDefault(user => user.Id == userId);
            user.Person.Address.Country = country;
            _context.SaveChanges();
        }

        public void UpdateCity(int userId, string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                throw new ValidationException();
            }
            User user = _context.Users.Include(user => user.Person).Include(user => user.Person.Address).FirstOrDefault(user => user.Id == userId);
            user.Person.Address.City = city;
            _context.SaveChanges();
        }
        public void UpdateStreet(int userId, string street)
        {
            if (string.IsNullOrEmpty(street))
            {
                throw new ValidationException();
            }
            User user = _context.Users.Include(user => user.Person).Include(user => user.Person.Address).FirstOrDefault(user => user.Id == userId);
            user.Person.Address.Street = street;
            _context.SaveChanges();
        }
        public void UpdateHouseNumber(int userId, int houseNumber)
        {
            User user = _context.Users.Include(user => user.Person).Include(user => user.Person.Address).FirstOrDefault(user => user.Id == userId);
            user.Person.Address.HouseNumber = houseNumber;
            _context.SaveChanges();
        }
        public void UpdateAppartmentNumber(int userId, int appartmentNumber)
        {
            User user = _context.Users.Include(user => user.Person).Include(user => user.Person.Address).FirstOrDefault(user => user.Id == userId);
            user.Person.Address.AppartmentNumber = appartmentNumber;
            _context.SaveChanges();
        }
    }
}
