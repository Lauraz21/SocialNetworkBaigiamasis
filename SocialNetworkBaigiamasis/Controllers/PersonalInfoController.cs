using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetworkBaigiamasis.Models;
using SocialNetworkBaigiamasis.Services;
using System.Security.Authentication;
using System.Security.Claims;

namespace SocialNetworkBaigiamasis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInfoController : ControllerBase
    {
        private readonly IPersonalInfoService _personalInfoService;

        public PersonalInfoController(IPersonalInfoService personalInfoService)
        {
            _personalInfoService = personalInfoService;
        }
        [HttpGet("[action]")]
        [Authorize]
        public ActionResult<PersonalInfo> GetPersonalInfo()
        {
           return _personalInfoService.GetPersonalInfo(GetLoggedInUserId());
        }
        [HttpPost("[action]")]
        [Authorize]
        public ActionResult UpdateName(string name)
        {
            _personalInfoService.UpdateName(GetLoggedInUserId(), name);
            return Ok();
        }
        [HttpPost("[action]")]
        [Authorize]
        public ActionResult UpdateLastName(string lastName)
        {
            _personalInfoService.UpdateLastName(GetLoggedInUserId(), lastName);
            return Ok();
        }
        [HttpPost("[action]")]
        [Authorize]
        public ActionResult UpdatePersonalCode(string personalCode)
        {
            _personalInfoService.UpdatePersonalCode(GetLoggedInUserId(), personalCode);
            return Ok();
        }
        [HttpPost("[action]")]
        [Authorize]
        public ActionResult UpdateTelephoneNumber(string telephoneNumber)
        {
            _personalInfoService.UpdateTelephoneNumber(GetLoggedInUserId(), telephoneNumber);
            return Ok();
        }
        [HttpPost("[action]")]
        [Authorize]
        public ActionResult UpdateEmail(string email)
        {
            _personalInfoService.UpdateEmail(GetLoggedInUserId(), email);
            return Ok();
        }
        [HttpPost("[action]")]
        [Authorize]
        public ActionResult UpdateProfilePicture(byte[] picture)
        {
            _personalInfoService.UpdateProfilePicture(GetLoggedInUserId(), picture);
            return Ok();
        }
        [HttpPost("[action]")]
        [Authorize]
        public ActionResult UpdateCountry(string country)
        {
            _personalInfoService.UpdateCountry(GetLoggedInUserId(), country);
            return Ok();
        }
        [HttpPost("[action]")]
        [Authorize]
        public ActionResult UpdateCity(string city)
        {
            _personalInfoService.UpdateCity(GetLoggedInUserId(), city);
            return Ok();
        }
        [HttpPost("[action]")]
        [Authorize]
        public ActionResult UpdateStreet(string street)
        {
            _personalInfoService.UpdateStreet(GetLoggedInUserId(), street);
            return Ok(); ;
        }
        [HttpPost("[action]")]
        [Authorize]
        public ActionResult UpdateHouseNumber(int houseNumber)
        {
            _personalInfoService.UpdateHouseNumber(GetLoggedInUserId(), houseNumber);
            return Ok();
        }
        [HttpPost("[action]")]
        [Authorize]
        public ActionResult UpdateAppartmentNumber(int appartmentNumber)
        {
            _personalInfoService.UpdateAppartmentNumber(GetLoggedInUserId(), appartmentNumber);
            return Ok();
        }

        private int GetLoggedInUserId()
        {
            if (!User.Identity.IsAuthenticated)
                throw new AuthenticationException();

            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            return int.Parse(userId);
        }
    }
}
