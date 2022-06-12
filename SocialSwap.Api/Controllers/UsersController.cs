using Microsoft.AspNetCore.Mvc;
using SocialSwap.Api.Attributes;
using SocialSwap.Api.Dtos;
using SocialSwap.Domain.AggregatesModel.UserAggregate;

namespace SocialSwap.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateModel model)
        {
            var user = await _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            User? identity = HttpContext.Items["User"] as User;
            if (identity == null)
                return BadRequest(identity);
            return Ok(users);
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUpDto signUpModel)
        {
            var auth = Domain.AggregatesModel.UserAggregate.User.HashPassword(signUpModel.Password);
            var address = new Address
            {
                Street = signUpModel.Street,
                City = signUpModel.City,
                Region = signUpModel.Region,
                Country = signUpModel.Country,
                Postcode = signUpModel.Postcode,
                BuildingNumber = signUpModel.BuildingNumber,
                FlatNumber = signUpModel.FlatNumber
            };
            var client = new Client
            {
                Name = signUpModel.Name,
                Surname = signUpModel.Surname,
                EmailAddress = signUpModel.EmailAddress,
                Birthdate = signUpModel.Birthdate,
                PhoneNumber = signUpModel.PhoneNumber,
                HashedPassword = auth.Hash,
                Salt = auth.Salt,
                RefreshToken = auth.RefreshToken,
                RefreshTokenExpirationDate = auth.RefreshTokenExpirationDate
            };
            var result = await _userService.SignUp(address, client);
            return Ok(result);
        }
    }
}
