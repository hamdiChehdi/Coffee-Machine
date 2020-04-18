using CoffeeApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BadgeController : ControllerBase
    {
        private readonly IBadgeService badgeService;

        public BadgeController(IBadgeService badgeService)
        {
            this.badgeService = badgeService;
        }

        // api/Badge/GetOnwer/BadgeNumber
        [HttpGet("GetOnwer/{badgeNumber}")]
        public string GetOnwer(string badgeNumber)
        {
            var owner = badgeService.GetOwner(badgeNumber);

            return owner;
        }
    }
}
