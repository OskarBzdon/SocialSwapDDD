using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialSwap.Api.Dtos;
using SocialSwap.Api.Services;
using SocialSwap.Domain.AggregatesModel.ItemAggregate;
using SocialSwap.Domain.AggregatesModel.UserAggregate;
using System.Security.Claims;

namespace SocialSwap.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ItemService _service;
        private readonly UserManager<User> _userManager;

        public ItemController(IItemService service, UserManager<User> userManager)
        {
            _service = (ItemService?)service;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            User? currentUser = null;
            if (this.User.Identity.Name != null)
                currentUser = await _userManager.FindByNameAsync(this.User?.Identity?.Name);
            return Ok(_service.Index(currentUser?.Id));
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("details")]
        public async Task<IActionResult> GetById([FromQuery]string id)
        {
            return Ok(_service.Get(id));
        }

        [Authorize]
        [HttpPost]
        [Route("additem")]
        public async Task<IActionResult> Create([FromQuery] DtoItem model)
        {
            var currentUser = await _userManager.FindByNameAsync(this.User.Identity.Name);
            Item entity = new Item() { Title = model.Title, Description = model.Description, Owner = currentUser as Client};
            return Ok(_service.Create(entity));
        }
    }
}
