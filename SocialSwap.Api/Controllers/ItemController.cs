using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialSwap.Api.Dtos;
using SocialSwap.Api.Services;
using SocialSwap.Domain.AggregatesModel;
using SocialSwap.Domain.AggregatesModel.ItemAggregate;
using SocialSwap.Domain.AggregatesModel.UserAggregate;

namespace SocialSwap.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _service;
        public ItemController(IItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_service.Index());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_service.Get(id));
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create([FromQuery] DtoItem model)
        {
            User? identity = HttpContext.Items["User"] as User;
            if (identity == null)
                return BadRequest(identity);
            DisplayedItem entity = new DisplayedItem() { Title = model.Title, Description = model.Description, DisplayDate = DateTime.Now};
            return Ok(_service.Create(entity));
        }

        [HttpPut("{model}")]
        public async Task<IActionResult> Update(Item model)
        {
            return Ok(_service.Update(model));
        }

        [HttpDelete("{model}")]
        public async Task<IActionResult> Delete(Item model)
        {
            return Ok(_service.Delete(model));
        }
    }
}
