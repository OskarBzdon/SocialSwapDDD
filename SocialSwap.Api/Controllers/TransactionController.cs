using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialSwap.Api.Dtos;
using SocialSwap.Domain.AggregatesModel.ItemAggregate;
using SocialSwap.Domain.AggregatesModel.TransactionAggregate;
using SocialSwap.Domain.AggregatesModel.UserAggregate;

namespace SocialSwap.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transService;
        private readonly IItemService _itemService;
        private readonly UserManager<User> _userManager;
        public TransactionController(ITransactionService service, UserManager<User> userManager, IItemService itemService)
        {
            _transService = service;
            _userManager = userManager;
            _itemService = itemService;
        }

        [HttpGet]
        [Route("seemyoffers")]
        public async Task<IActionResult> GetAllMyTransactions()
        {
            var currentUser = await _userManager.FindByNameAsync(this.User.Identity.Name);
            return Ok(_transService.GetAllMyTransactions(currentUser.Id));
        }

        [HttpPost]
        [Route("swapitem")]
        public async Task<IActionResult> SwapWthItem([FromBody] SwapDto delivery)
        {
            Transaction transaction = new Transaction();
            var diplayedItem = _itemService.Get(delivery.wantedItemId);
            transaction.WantedItem = diplayedItem;
            transaction.Receiver = await _userManager.FindByIdAsync(transaction.WantedItem.Owner.Id) as Client;
            transaction.OfferedItem = _itemService.Get(delivery.offeredItemId);
            transaction.DeliveryTime = delivery.deliveryTime;
            transaction.DeliveryType = delivery.deliveryType;
            return Ok(_transService.CreateTransaction(transaction));
        }

        [HttpPut]
        [Route("confirmoffer")]
        public async Task<IActionResult> ConfirmTransaction([FromQuery]string transactionId)
        {
            return Ok(_transService.ConfirmTransaction(transactionId));
        }
    }
}
